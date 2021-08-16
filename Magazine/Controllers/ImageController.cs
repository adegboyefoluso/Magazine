using Magazine.MOdel.EventFolder;
using Magazine.MOdel.ImageFolder;
using Magazine.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magazine.Controllers
{
    public class ImageController : Controller
    {

        private ImageServices CreateImageServices()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new ImageServices(userid);
            return service;
        }

        private EventServices CreateEventServices()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new EventServices(userid);
            return service;
        }

        // GET: Image
        public ActionResult Index()
        {
            var service = CreateImageServices();
            return View(service.GetAllImage());
        }


        //GET: IMAGE CREATE
        public ActionResult Create()
        {
            var service = CreateEventServices();
            List<EventListItem> EventItem = service.GetAllEvents().ToList();
            EventListItem category = new EventListItem() { EventId = 0, EventName = "Select Event" };
            EventItem.Add(category);
            ViewBag.List = new SelectList(EventItem.OrderBy(c => c.EventId).ToList(), "EventId", "EventName");
            return View();
        }

        //POST:IMAGE/ CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateImageServices();
           
            if (service.CreateImage(model))
            {
                TempData["SaveResult"] = "Image Added";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Image could not be added");
            return View(model);
        }
    }
}