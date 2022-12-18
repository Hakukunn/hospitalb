﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;

namespace WebHospital.Controllers
{
    public class medicalPersonnelController : Controller
    {
        private Model1 db = new Model1();

        // GET: medicalPersonnel
        public ActionResult Index()
        {
            return View(db.medicalPersonnel.ToList());
        }

        // GET: medicalPersonnel/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicalPersonnel medicalPersonnel = db.medicalPersonnel.Find(id);
            if (medicalPersonnel == null)
            {
                return HttpNotFound();
            }
            return View(medicalPersonnel);
        }

        // GET: medicalPersonnel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: medicalPersonnel/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "medicalPersonnelID,IDNumber,name,isExpert,introduction,job,title,isDimission,gender,age,contactInformation,birthday,department")] medicalPersonnel medicalPersonnel)
        {
            if (ModelState.IsValid)
            {
                db.medicalPersonnel.Add(medicalPersonnel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicalPersonnel);
        }

        // GET: medicalPersonnel/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicalPersonnel medicalPersonnel = db.medicalPersonnel.Find(id);
            if (medicalPersonnel == null)
            {
                return HttpNotFound();
            }
            return View(medicalPersonnel);
        }

        // POST: medicalPersonnel/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "medicalPersonnelID,IDNumber,name,isExpert,introduction,job,title,isDimission,gender,age,contactInformation,birthday,department")] medicalPersonnel medicalPersonnel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalPersonnel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicalPersonnel);
        }

        // GET: medicalPersonnel/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicalPersonnel medicalPersonnel = db.medicalPersonnel.Find(id);
            if (medicalPersonnel == null)
            {
                return HttpNotFound();
            }
            return View(medicalPersonnel);
        }

        // POST: medicalPersonnel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            medicalPersonnel medicalPersonnel = db.medicalPersonnel.Find(id);
            db.medicalPersonnel.Remove(medicalPersonnel);
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
