using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManager.Models;

namespace EventManager.Controllers
{
    public class EventController : Controller
    {
        // GET: Event/Index
        public ActionResult Index()
        {
            using (EventManagerEntities dbModel = new EventManagerEntities())
            {
                return View(dbModel.Events.ToList());
            }
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(Event e)
        {
            try
            {
                // TODO: Add insert logic here
                using (EventManagerEntities dbModel = new EventManagerEntities())
                {
                    dbModel.Events.Add(e);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            using (EventManagerEntities dbModel = new EventManagerEntities())
            {
                return View(dbModel.Events.Where(x => x.EventId == id).FirstOrDefault());
            }
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Event e)
        {
            try
            {
                // TODO: Add update logic here
                using (EventManagerEntities dbModel = new EventManagerEntities())
                {
                    dbModel.Entry(e).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            using (EventManagerEntities dbModel = new EventManagerEntities())
            {
                return View(dbModel.Events.Where(x => x.EventId == id).FirstOrDefault());
            }
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (EventManagerEntities dbModel = new EventManagerEntities())
                {
                    Event e = dbModel.Events.Where(x => x.EventId == id).FirstOrDefault();
                    dbModel.Events.Remove(e);
                    dbModel.SaveChanges();
                }
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
