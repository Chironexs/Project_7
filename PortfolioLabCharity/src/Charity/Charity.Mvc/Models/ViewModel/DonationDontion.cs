using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Charity.Mvc.Models.DbModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Query.SemanticAst;

namespace Charity.Mvc.Models.ViewModel
{
    public class DonationDontion
    {
        public ICollection<Category> CategoryICollection { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public ICollection<Institution> InstitutionICollection { get; set; }
        public List<SelectListItem> Institutions { get; set; }
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Wartość musi być większa od 0")]
        [Required(ErrorMessage = "Ilość jest wymagana")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Instytucja jest wymagana")]
        public int InstitutionId { get; set; }

        [Required(ErrorMessage = "Ulica jest wymagana")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Nazwa miasta jest wymagana")]
        public string City { get; set; }

        [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Data jest wymagana")]
        public DateTime PickUpDate { get; set; }

        [Required(ErrorMessage = "Godzina jest wymagana")]
        public DateTime PickUpTime { get; set; }

        public string PickUpComment { get; set; }
    }
}