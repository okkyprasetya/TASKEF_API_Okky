using MyRESTServices.BLL.DTOs;
using MyWebFormApp.BLL.DTOs;
using System.Collections.Generic;
using ArticleCreateDTO = MyRESTServices.BLL.DTOs.ArticleCreateDTO;
using ArticleDTO = MyRESTServices.BLL.DTOs.ArticleDTO;
using ArticleUpdateDTO = MyRESTServices.BLL.DTOs.ArticleUpdateDTO;

namespace MyRESTServices.BLL.Interfaces
{
    public interface IArticleBLL
    {
        Task<Task> Insert(ArticleCreateDTO article);
        Task<IEnumerable<ArticleDTO>> GetAll();
        Task<IEnumerable<ArticleDTO>> GetArticleWithCategory();
        Task<IEnumerable<ArticleDTO>> GetArticleByCategory(int categoryId);
        Task<int> InsertWithIdentity(ArticleCreateDTO article);
        Task<Task> Update(ArticleUpdateDTO article);
        Task<bool> Delete(int id);
        Task<ArticleDTO> GetArticleById(int id);
        Task<IEnumerable<ArticleDTO>> GetWithPaging(int categoryId, int pageNumber, int pageSize);
        Task<int> GetCountArticles();
    }
}
