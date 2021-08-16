using Magazine.MOdel.CategoryFolder;
using Magazine.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magazine.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        
        private CategoryServices CreateCategoryServices()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryServices(userid);
            return service;
        }
        // GET: Category
        public ActionResult Index()
        {
            var service = CreateCategoryServices();
            
            return View(service.GetAllCategory());
        }


        //GET:CREATE Category
        public ActionResult Create( ) 
        {

            return View();
        }
        //POST:CREATE CATEGORY

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            var service = CreateCategoryServices();
            if (!ModelState.IsValid) return View();
            if (service.CreateCategory(model))
            {
                return RedirectToAction("Index");
            }
            else return View(model);
        }

        //GET : Category
        public ActionResult Details(int id)
        {
            var service = CreateCategoryServices();
            return View(service.GetCagtegoryById(id));
        }
    }
}