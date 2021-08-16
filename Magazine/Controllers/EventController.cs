using Magazine.MOdel.CategoryFolder;
using Magazine.MOdel.EventFolder;
using Magazine.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magazine.Controllers
{
    public class EventController : Controller
    {

        private EventServices CreateEventServices()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new EventServices(userid);
            return service;
        }

        private CategoryServices CreateCategoryServices()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryServices(userid);
            return service;
        }
        // GET: Event
        public ActionResult Index()
        {
            var services = CreateEventServices();

            return View(services.GetAllEvents());
        }

        //GET: EVENT CREATE
        public ActionResult Create()
        {
            var service = CreateCategoryServices();
            List<CategoryListItem> categoryItem = service.GetAllCategory().ToList();
            CategoryListItem category = new CategoryListItem() { CategoryId = 0, CategoryName = "Select Category" };
            categoryItem.Add(category);
            ViewBag.List = new SelectList(categoryItem.OrderBy(c => c.CategoryId).ToList(), "CategoryId", "CategoryName");
            return View();
        }
        //POST:EVENT/ CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (EventCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateEventServices();
            //if (model.CategoryId == 0)
            //{
            //    model.CategoryId = null;
            //}
            if (service.CreateEvent(model))
            {
                TempData["SaveResult"] = "Member added to the church Directory";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Member could not be added");
            return View(model);
        }

        //GET:EVENT/DETAILS
        public ActionResult Details(int id)
        {
            var service = CreateEventServices();
            return View(service.EventDetails(id));
        }
        //Get :Image
        public ActionResult GetAllImages(int id)
        {
            
            var service = CreateEventServices();
            ViewBag.List = service.EventDetails(id).EventDetails;
            ViewBag.List1 = service.EventDetails(id).EventName;
            return View(service.GetAlLImage(id));
        }

    }
}