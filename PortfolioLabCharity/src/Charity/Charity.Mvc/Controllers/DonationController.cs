using Charity.Mvc.Models.DbModels;
using Charity.Mvc.Models.ViewModel;
using Charity.Mvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Charity.Mvc.Controllers
{
    public class DonationController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IDonationService _donationService;
        private readonly IInstitutionService _institutionService;


        public DonationController(ICategoryService categoryService, IDonationService donationService,
            IInstitutionService institutionService
        )
        {
            _categoryService = categoryService;
            _donationService = donationService;
            _institutionService = institutionService;
        }

        [HttpGet]
        public IActionResult Donation()
        {
            DonationDontion donationDonation = new DonationDontion();
            donationDonation.CategoryICollection = _categoryService.GetAll();
            donationDonation.Categories = new List<SelectListItem>();

            foreach (var item in donationDonation.CategoryICollection)
            {
                donationDonation.Categories.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            donationDonation.InstitutionICollection = _institutionService.GetAll();
            donationDonation.Institutions = new List<SelectListItem>();

            foreach (var item in donationDonation.InstitutionICollection)
            {
                donationDonation.Institutions.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            @ViewBag.Info = "Oddaj rzeczy, których już nie chcesz";
            @ViewBag.InfoUppercase = "potrzebującym";
            return View(donationDonation);
        }

        [HttpPost]
        public IActionResult ConfirmationOfAdding(DonationDontion donationDonation)
        {
            if (ModelState.IsValid)
            {
                Donation donation = new Donation();
                donation.DonationCategory = new List<DonationCategory>();
                var listOfCheckedCategoryId = donationDonation.Categories.Where(a => a.Selected == true)
                    .Select(a => a.Value).ToList();
                foreach (var item in listOfCheckedCategoryId)
                {
                    donation.DonationCategory.Add(new DonationCategory()
                    {
                        CategoryId = Int32.Parse(item)
                    });
                }

                donation.Quantity = donationDonation.Quantity;
                donation.InstitutionId = donationDonation.InstitutionId;
                donation.Street = donationDonation.Street;
                donation.City = donationDonation.City;
                donation.ZipCode = donationDonation.ZipCode;
                donation.PickUpDate = donationDonation.PickUpDate;
                donation.PickUpTime = donationDonation.PickUpTime;
                donation.PickUpComment = donationDonation.PickUpComment;

                _donationService.Create(donation);
                @ViewBag.Info =
                    "Dziękujemy za przesłanie formularza. Na maila prześlemy wszelkie informacje o odbiorze.";
                return View("ConfirmationOfAdding", donationDonation);
            }
            return View("Donation", donationDonation);
        }
    }
}