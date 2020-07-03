using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;

        // GET: Restaurants

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {

            var model = db.GetAll();

            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
         public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaruant restaurant )
        {
           
            if(ModelState.IsValid)
            { 
            db.Add(restaurant);
                return RedirectToAction("Details",new {id = restaurant.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Restaruant restaruant)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaruant);
                TempData["message"] = "You have saved The Resturant";
                return RedirectToAction("Details", new { id = restaruant.Id });
            }
            return View(restaruant);
        }

        [HttpGet]
        public ActionResult Delete (int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (int id,FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");

        }
    }
}