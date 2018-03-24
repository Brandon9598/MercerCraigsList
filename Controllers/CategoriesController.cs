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
        public ActionResult Catagories()
        {
            return View();
        }
    }
}