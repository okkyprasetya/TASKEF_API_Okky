using AutoMapper;
using MyRESTServices.BLL.DTOs;
using MyRESTServices.BLL.Interfaces;
using MyRESTServices.Data;
using MyRESTServices.Data.Interfaces;
using MyRESTServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRESTServices.BLL
{
    public class CategoryBLL : ICategoryBLL
    {
        private readonly ICategoryData _category;
        private readonly IMapper _mapper;

        public CategoryBLL(ICategoryData categoryData, IMapper mapper)
        {
            _category = categoryData;
            _mapper = mapper;
        }
        public async Task<Task> Delete(int id)
        {
            var checkExist = await _category.GetById(id);
            await _category.Delete(checkExist.CategoryId);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var categories = await _category.GetAll();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return categoriesDto;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var category = await _category.GetById(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetByName(string name)
        {
            var categories = await _category.GetByName(name);
            var listCategory = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return listCategory;
        }

        public Task<int> GetCountCategories(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDTO>> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> Insert(CategoryCreateDTO entity)
        {
            var newCat = _mapper.Map<Category>(entity);
            await _category.Insert(newCat);

            return Task.CompletedTask;
        }

        public async Task<Task> Update(CategoryUpdateDTO entity)
        {
            var existingCategory = await _category.GetById(entity.CategoryID);
            if (existingCategory == null)
            {
                throw new Exception("Category not found");
            }
            _mapper.Map(entity, existingCategory);

            await _category.Update(existingCategory);

            return Task.CompletedTask;
        }
    }
}
