using Charity.Mvc.Models.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Charity.Mvc.Services.Interfaces
{
    public interface IDonationService
    {
        Task<bool> Create(Donation donation);
        bool Delete(int id);
        Donation Get(int id);
        IList<Donation> GetAll();
        int SupportedOrganization();
        int TransferredBags();
        bool Update(Donation donation);
    }
}