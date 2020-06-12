using Charity.Mvc.Models.DbModels;
using Charity.Mvc.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Mvc.Services
{
    public class DonationService : IDonationService
    {
        private readonly Context _context;

        public DonationService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Create(Donation donation)
        {
            _context.Donations.Add(donation);

//            return (await _context.SaveChangesAsync() > 0) ? true : false;
            return (await _context.SaveChangesAsync() > 0);
        }

        public bool Delete(int id)
        {
            var donation = _context.Donations.SingleOrDefault(a => a.Id == id);

            if (donation == null)
            {
                return false;
            }

            _context.Donations.Remove(donation);

            return _context.SaveChanges() > 0;
        }

        public Donation Get(int id)
        {
            return _context.Donations.SingleOrDefault(a => a.Id == id);
        }

        public IList<Donation> GetAll()
        {
            return _context.Donations.ToList();
        }

        public int SupportedOrganization()
        {
//            return _context.Donations.GroupBy(x => x.InstitutionId).Select(y => y.First()).ToList().Count;
            return _context.Donations.Select(x => x.InstitutionId).Distinct().Count();
        }
        public int TransferredBags()
        {
            return _context.Donations.Select(a => a.Quantity).ToList().Sum();
        }

        public bool Update(Donation donation)
        {
            _context.Donations.Update(donation);

            return _context.SaveChanges() > 0;
        }
    }
}