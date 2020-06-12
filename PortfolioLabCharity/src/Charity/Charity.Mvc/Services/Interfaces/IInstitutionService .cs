using Charity.Mvc.Models.DbModels;
using System.Collections.Generic;

namespace Charity.Mvc.Services.Interfaces
{
    public interface IInstitutionService
    {
        bool Create(Institution institution);
        bool Delete(int id);
        Institution Get(int id);
        IList<Institution> GetAll();
        bool Update(Institution institution);
    }
}