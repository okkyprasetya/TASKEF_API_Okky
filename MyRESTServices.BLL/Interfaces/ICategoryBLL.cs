using MyRESTServices.BLL.DTOs;
using MyWebFormApp.BLL.DTOs;
using System.Collections.Generic;
using CategoryCreateDTO = MyRESTServices.BLL.DTOs.CategoryCreateDTO;
using CategoryDTO = MyRESTServices.BLL.DTOs.CategoryDTO;
using CategoryUpdateDTO = MyRESTServices.BLL.DTOs.CategoryUpdateDTO;

namespace MyRESTServices.BLL.Interfaces
{
    public interface ICategoryBLL
    {
        Task<Task> Delete(int id);
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<CategoryDTO> GetById(int id);
        Task<IEnumerable<CategoryDTO>> GetByName(string name);
        Task<Task> Insert(CategoryCreateDTO entity);
        Task<Task> Update(CategoryUpdateDTO entity);
        Task<IEnumerable<CategoryDTO>> GetWithPaging(int pageNumber, int pageSize, string name);
        Task<int> GetCountCategories(string name);
    }
}
