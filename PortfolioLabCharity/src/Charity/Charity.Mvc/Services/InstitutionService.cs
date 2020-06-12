using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Mvc.Models.DbModels;
using Charity.Mvc.Services.Interfaces;

namespace Charity.Mvc.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly Context _context;

        public InstitutionService(Context context)
        {
            _context = context;
        }
        public bool Create(Institution institution)
        {
            _context.Institutions.Add(institution);

            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var institution = _context.Institutions.SingleOrDefault(a => a.Id == id);

            if (institution == null)
            {
                return false;
            }

            _context.Institutions.Remove(institution);

            return _context.SaveChanges() > 0;
        }

        public Institution Get(int id)
        {
            return _context.Institutions.SingleOrDefault(a => a.Id == id);
        }

        public IList<Institution> GetAll()
        {
            return _context.Institutions.ToList();
        }

        public bool Update(Institution institution)
        {
            _context.Institutions.Update(institution);

            return _context.SaveChanges() > 0;
        }
    }
}
