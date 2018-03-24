using Mercer_Craigslist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mercer_Craigslist.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public CategoriesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Categories
        public ActionResult Categories()
        {
            List<Category> CategoriesList = new List<Category>();
            var categories = Enum.GetValues(typeof(Category));
            foreach(Category category in categories)
            {
                CategoriesList.Add(category);
            }

            return View(CategoriesList);
        }

        public ActionResult Category(Category categoryID)
        {
            var allItems = _dbContext.Items.ToList();
            var categoryItems = allItems.Where(c => c.Category == categoryID);

            return View(categoryItems);
        }

        //public ActionResult Detail(int itemID)
        //{
        //    var item = _dbContext.Items.SingleOrDefault(i => i.Id == itemID);
        //    if (item == null)
        //        return HttpNotFound();
        //    return RedirectToAction("Detail", "Items", item);
            
        //}

    }
}