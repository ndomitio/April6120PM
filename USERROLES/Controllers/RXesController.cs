﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using USERROLES.Models;

namespace USERROLES.Controllers
{
    public class RXesController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: RXes
        public ActionResult Index()
        {
            return View(db.RXes.ToList());
        }

        // GET: RXes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RX rX = db.RXes.Find(id);
            if (rX == null)
            {
                return HttpNotFound();
            }
            return View(rX);
        }

        // GET: RXes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RxID,RxName,ExID,PID,PhID,LogID")] RX rX)
        {
            if (ModelState.IsValid)
            {
                db.RXes.Add(rX);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rX);
        }

        // GET: RXes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RX rX = db.RXes.Find(id);
            if (rX == null)
            {
                return HttpNotFound();
            }
            return View(rX);
        }

        // POST: RXes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RxID,RxName,ExID,PID,PhID,LogID")] RX rX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rX);
        }

        // GET: RXes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RX rX = db.RXes.Find(id);
            if (rX == null)
            {
                return HttpNotFound();
            }
            return View(rX);
        }

        // POST: RXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RX rX = db.RXes.Find(id);
            db.RXes.Remove(rX);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
