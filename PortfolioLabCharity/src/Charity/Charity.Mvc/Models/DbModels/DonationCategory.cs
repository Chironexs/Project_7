using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Mvc.Models.DbModels
{
    public class DonationCategory
    {
        public int Id { get; set; }
        [ForeignKey("Donation")] public int DontaionId { get; set; }
        public Donation Donation { get; set; }

        [ForeignKey("Category")] public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}