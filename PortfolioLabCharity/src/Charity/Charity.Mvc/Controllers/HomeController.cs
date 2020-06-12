using Charity.Mvc.Models;
using Charity.Mvc.Models.ViewModel;
using Charity.Mvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Charity.Mvc.Models.ItemSelect;

namespace Charity.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDonationService _donationService;
        private readonly IInstitutionService _institutionService;


        public HomeController(IDonationService donationService,
            IInstitutionService institutionService
        )
        {
            _donationService = donationService;
            _institutionService = institutionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            HomeIndex homeIndex = new HomeIndex();
            var getAll = _institutionService.GetAll();
            homeIndex.ListOfInstitutions = new List<InstitutionSelectList>();
            var number = 0;
            foreach (var item in getAll)
            {
                homeIndex.ListOfInstitutions.Add(new InstitutionSelectList
                {
                    Name = item.Name,
                    Description = item.Description,
                    Number = number++
                });
            }

            homeIndex.SupportedOrganization = _donationService.SupportedOrganization();
            homeIndex.TransferredBags = _donationService.TransferredBags();

            return View(homeIndex);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}