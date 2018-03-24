using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mercer_Craigslist.Models;

namespace Mercer_Craigslist.Controllers
{
    public class ItemsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ItemsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Items
        public ActionResult Index()
        {
            var items = _dbContext.Items.ToList();

            return View(items);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Add(Item item)
        {
            string fileName = Path.GetFileNameWithoutExtension(item.ImageFile.FileName);
            string extension = Path.GetExtension(item.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            item.ImagePath = "~/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
            item.ImageFile.SaveAs(fileName);
            _dbContext.Items.Add(item);
            _dbContext.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var item = _dbContext.Items.SingleOrDefault(i => i.Id == id);
            if (item == null)
                return HttpNotFound();
            return View(item);
           
        }

        public ActionResult Edit(int id)
        {
            var item = _dbContext.Items.SingleOrDefault(i => i.Id == id);

            if(item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        public ActionResult Update(Item item)
        {
            var itemInDb = _dbContext.Items.SingleOrDefault(i => i.Id == item.Id);

            if (itemInDb == null)
                return HttpNotFound();

            itemInDb.Title = item.Title;
            itemInDb.Description = item.Description;
            itemInDb.Cost = item.Cost;
            itemInDb.OwnerEmail = item.OwnerEmail;
            itemInDb.Category = item.Category;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = _dbContext.Items.SingleOrDefault(i => i.Id == id);

            if (item == null)
                return HttpNotFound();

            return View(item);
        }

        [HttpPost]
        public ActionResult DoDelete(int id)
        {
            var item = _dbContext.Items.SingleOrDefault(i => i.Id == id);
            if (item == null)
                return HttpNotFound();
            _dbContext.Items.Remove(item);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}