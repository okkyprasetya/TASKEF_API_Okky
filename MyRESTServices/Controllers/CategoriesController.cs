using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyRESTServices.BLL.DTOs;
using MyRESTServices.BLL.Interfaces;
using MyWebFormApp.BLL.DTOs;
using CategoryCreateDTO = MyRESTServices.BLL.DTOs.CategoryCreateDTO;
using CategoryDTO = MyRESTServices.BLL.DTOs.CategoryDTO;
using CategoryUpdateDTO = MyRESTServices.BLL.DTOs.CategoryUpdateDTO;

namespace MyRESTServices.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IValidator<CategoryCreateDTO> _validator;
        private readonly IValidator<CategoryUpdateDTO> _updateValidator;
        private readonly ICategoryBLL _categoryBLL;
        public CategoriesController(ICategoryBLL categoryBLL, IValidator<CategoryCreateDTO> validator, IValidator<CategoryUpdateDTO> updateValidator)
        {
            _categoryBLL = categoryBLL;
            _validator = validator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            var results = await _categoryBLL.GetAll();
            return results;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryBLL.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryCreateDTO categoryCreateDTO)
        {
            var validationResult = await _validator.ValidateAsync(categoryCreateDTO);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            if (categoryCreateDTO == null)
            {
                return BadRequest();
            }

            try
            {
                await _categoryBLL.Insert(categoryCreateDTO);
                return Ok("Insert data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CategoryUpdateDTO categoryUpdateDTO)
        {
            var validationResult = await _updateValidator.ValidateAsync(categoryUpdateDTO);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            try
            {
                await _categoryBLL.Update(categoryUpdateDTO);
                return Ok("Update data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryBLL.Delete(id);
                return Ok("Delete data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
