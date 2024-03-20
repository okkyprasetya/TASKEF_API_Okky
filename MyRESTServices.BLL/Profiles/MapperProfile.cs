using AutoMapper;
using MyRESTServices.BLL.DTOs;
using MyRESTServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRESTServices.BLL.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile() { 
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<CategoryCreateDTO, CategoryDTO>();
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();
            CreateMap<CategoryUpdateDTO, CategoryDTO>();

            CreateMap<Article,ArticleDTO>().ReverseMap();
            CreateMap<ArticleCreateDTO, Article>().ReverseMap();
            CreateMap<ArticleCreateDTO, ArticleDTO>();
            CreateMap<ArticleUpdateDTO, Article>();
            CreateMap<ArticleUpdateDTO, ArticleDTO>();


            CreateMap<Role,RoleDTO>().ReverseMap();
        }
    }
}
