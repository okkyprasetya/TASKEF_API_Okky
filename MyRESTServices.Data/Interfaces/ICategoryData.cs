﻿
using MyRESTServices.Domain;
using System.Collections.Generic;

namespace MyRESTServices.Data.Interfaces
{
    public interface ICategoryData : ICrudData<Category>
    {
        Task<IEnumerable<Category>> GetByName(string name);
        Task<IEnumerable<Category>> GetWithPaging(int pageNumber, int pageSize, string name);
        Task<int> GetCountCategories(string name);
        Task<int> InsertWithIdentity(Category category);
    }
}
