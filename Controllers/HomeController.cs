using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Models;
using TravelBlog.ViewModels;

namespace TravelBlog.Controllers
{
    public class HomeController : Controller
    {
        private DestinationsDBEntities _db = new DestinationsDBEntities();

        // GET: Home
        public ActionResult Index()
        {
            var destinations = (
                from d in _db.Destinations 
                //join c in _db.Countries on d.CountryId equals c.Id  /* 2. 2 tables - no FK defined in DB */
                select new DestinationCountry
                {
                    Id=d.Id,
                    Name=d.Name,
                    Description=d.Description,
                    //CountryName=c.Name /* 2. 2 tables - no FK defined in DB */
                    CountryName = d.Country.Name /* 3. 2 tables - FK defined in DB */
                }
            ).ToList();

            //return View(_db.Destinations.ToList()); /* 1. One table */
            return View(destinations);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var destination = (from d in _db.Destinations where d.Id == id
                               select new DestinationCountry
                               {
                                   Id = d.Id,
                                   Name = d.Name,
                                   Description = d.Description,
                                   CountryName = d.Country.Name 
                               }).First();

            return View(destination);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            List<Country> list = _db.Countries.ToList();
            ViewData["CountryList"] = new SelectList(list, "Id", "Name");
            //ViewData["CountryId"] = new SelectList(list, "Id", "Name");
            // https://stackoverflow.com/questions/2849341/there-is-no-viewdata-item-of-type-ienumerableselectlistitem-that-has-the-key

            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Id")] Destination destinationToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Destinations.Add(destinationToCreate);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var destinationToEdit = (from d in _db.Destinations where d.Id == id select d).First();

            return View(destinationToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Destination destinationToEdit)
        {
            var originalDestination = (from d in _db.Destinations where d.Id == destinationToEdit.Id select d).First();

            if (!ModelState.IsValid)
                return View(originalDestination);

            _db.Entry(originalDestination).CurrentValues.SetValues(destinationToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
