using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRESTServices.BLL.DTOs;
using MyRESTServices.BLL.Interfaces;

namespace MyRESTServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleBLL _articleBLL;

        public ArticlesController(IArticleBLL articleBLL)
        {
            _articleBLL = articleBLL;
        }

        [HttpGet]
        public async Task<IEnumerable<ArticleDTO>> Get()
        {
            var results = await _articleBLL.GetAll();
            return results;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _articleBLL.GetArticleById(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetArticleByCategory(int categoryId)
        {
            try
            {
                var articles = await _articleBLL.GetArticleByCategory(categoryId);
                return Ok(articles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("withcategory")]
        public async Task<IActionResult> GetArticleWithCategory()
        {
            try
            {
                var articles = await _articleBLL.GetArticleWithCategory();
                return Ok(articles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleCreateDTO articleCreateDTO)
        {
            try
            {
                await _articleBLL.Insert(articleCreateDTO);
                return Ok("Article created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, ArticleUpdateDTO articleUpdateDTO)
        {
            try
            {
                if (id != articleUpdateDTO.ArticleID)
                    return BadRequest("Invalid ID provided");

                await _articleBLL.Update(articleUpdateDTO);
                return Ok("Article updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            try
            {
                var result = await _articleBLL.Delete(id);
                if (!result)
                    return NotFound();

                return Ok("Article deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
