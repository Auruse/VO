using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TEF.Models;

namespace TEF.Controllers
{
    public class TestAccRecordsController : Controller
    {
        private Tests db = new Tests();
        
       
        // GET: TestAccRecords
        public ActionResult Index()
        {
            
            return View(db.TestAccRecords);
        }
        
        public ActionResult RecordRnd(int? id)
        {
            if(id.HasValue || id<= db.TestAccRecords.Count())
            {
             TestAccRecord testAccRecord = null;

             testAccRecord = db.TestAccRecords.Find(id);
                return View(testAccRecord);
            }
            

            return View("Index");
        }
        
        // GET: TestAccRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestAccRecord testAccRecord = db.TestAccRecords.Find(id);
            if (testAccRecord == null)
            {
                return HttpNotFound();
            }
            return View(testAccRecord);
        }

        // GET: TestAccRecords/Create
        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.TestAccRecords, "Id", "Desc");
            return View();
        }

        // POST: TestAccRecords/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Dt,Ct,Desc,Answers,CorrectAnswer,SubjectId")] TestAccRecord testAccRecord)
        {
            if (ModelState.IsValid)
            {
                db.TestAccRecords.Add(testAccRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.SubjectId = new SelectList(db.TestsDescs, "Id", "Description", testAccRecord.SubjectId);
            return View(testAccRecord);
        }

        // GET: TestAccRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestAccRecord testAccRecord = db.TestAccRecords.Find(id);
            if (testAccRecord == null)
            {
                return HttpNotFound();
            }
            //ViewBag.SubjectId = new SelectList(db.TestsDescs, "Id", "Description", testAccRecord.SubjectId);
            return View(testAccRecord);
        }

        // POST: TestAccRecords/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Dt,Ct,Desc,Answers,CorrectAnswer,SubjectId")] TestAccRecord testAccRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testAccRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.SubjectId = new SelectList(db.TestsDescs, "Id", "Description", testAccRecord.SubjectId);
            return View(testAccRecord);
        }

        // GET: TestAccRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestAccRecord testAccRecord = db.TestAccRecords.Find(id);
            if (testAccRecord == null)
            {
                return HttpNotFound();
            }
            return View(testAccRecord);
        }

        // POST: TestAccRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestAccRecord testAccRecord = db.TestAccRecords.Find(id);
            db.TestAccRecords.Remove(testAccRecord);
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
