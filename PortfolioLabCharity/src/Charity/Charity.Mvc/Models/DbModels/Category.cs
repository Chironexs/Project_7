using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Mvc.Models.DbModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DonationCategory> DonationCategory { get; set; }
    }
}