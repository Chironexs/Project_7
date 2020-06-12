﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Mvc.Models.DbModels;
using Charity.Mvc.Services.Interfaces;

namespace Charity.Mvc.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly Context _context;

        public CategoryService(Context context)
        {
            _context = context;
        }

        public bool Create(Category category)
        {
            _context.Categories.Add(category);

            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(a => a.Id == id);

            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);

            return _context.SaveChanges() > 0;
        }

        public Category Get(int id)
        {
            return _context.Categories.SingleOrDefault(a => a.Id == id);
        }

        public IList<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public bool Update(Category category)
        {
            _context.Categories.Update(category);

            return _context.SaveChanges() > 0;
        }
    }
}