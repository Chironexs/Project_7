using Charity.Mvc.Models.DbModels;
using System.Collections.Generic;

namespace Charity.Mvc.Services.Interfaces
{
    public interface ICategoryService
    {
        bool Create(Category category);
        bool Delete(int id);
        Category Get(int id);
        IList<Category> GetAll();
        bool Update(Category category);
    }
}