using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParentsDateNight.Models;

namespace ParentsDateNight.Controllers
{
    public class SitterController : Controller
    {
        ApplicationDbContext context;
        public SitterController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Sitters
        public ActionResult Index()
        {
            return View(context.Sitters.ToList());
        }

        // GET: Sitters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sitter sitter = context.Sitters.Find(id);
            if (sitter == null)
            {
                return HttpNotFound();
            }
            return View(sitter);
        }

        // GET: Sitters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sitters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastNameInitial,ZipCode,Details")] Sitter sitter)
        {
            if (ModelState.IsValid)
            {
                context.Sitters.Add(sitter);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sitter);
        }

        // GET: Sitters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sitter sitter = context.Sitters.Find(id);
            if (sitter == null)
            {
                return HttpNotFound();
            }
            return View(sitter);
        }

        // POST: Sitters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastNameInitial,ZipCode,Details")] Sitter sitter)
        {
            if (ModelState.IsValid)
            {
                context.Entry(sitter).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sitter);
        }

        // GET: Sitters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sitter sitter = context.Sitters.Find(id);
            if (sitter == null)
            {
                return HttpNotFound();
            }
            return View(sitter);
        }

        // POST: Sitters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sitter sitter = context.Sitters.Find(id);
            context.Sitters.Remove(sitter);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
