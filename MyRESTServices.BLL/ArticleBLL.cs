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
    public class ArticleBLL : IArticleBLL
    {
        private readonly IArticleData _article;
        private readonly IMapper _mapper;

        public ArticleBLL(IArticleData article,IMapper mapper)
        {
            _article = article;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var article = await _article.GetById(id);
                if(article == null)
                {
                    throw new ArgumentException("article not found");
                }
                return await _article.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<ArticleDTO>> GetAll()
        {
            var articles = await _article.GetAll();
            var categoriesDTO = _mapper.Map<IEnumerable<ArticleDTO>>(articles);
            return categoriesDTO;
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticleByCategory(int categoryId)
        {
            //var article = await _article.GetById(categoryId);
            //return _mapper.Map<IEnumerable<ArticleDTO>>(article);

            var articles = await _article.GetArticleByCategory(categoryId);
            var articleDTOs = _mapper.Map<IEnumerable<ArticleDTO>>(articles);
            return articleDTOs;
        }

        public async Task<ArticleDTO> GetArticleById(int id)
        {
            var article = await _article.GetById(id);
            return _mapper.Map<ArticleDTO>(article);
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticleWithCategory()
        {
            var articles = await _article.GetArticleWithCategory();
            return _mapper.Map<IEnumerable<ArticleDTO>>(articles);
        }

        public Task<int> GetCountArticles()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArticleDTO>> GetWithPaging(int categoryId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> Insert(ArticleCreateDTO article)
        {
            var newArt = _mapper.Map<Article>(article);
            await _article.Insert(newArt);
            return Task.CompletedTask;
        }

        public Task<int> InsertWithIdentity(ArticleCreateDTO article)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> Update(ArticleUpdateDTO article)
        {
            var existingCategory = await _article.GetById(article.ArticleID);
            if(existingCategory == null) {
                throw new Exception("Article not found");
            }
            _mapper.Map(article, existingCategory);
            await _article.Update(existingCategory);

            return Task.CompletedTask;
        }
    }
}
