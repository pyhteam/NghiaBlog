using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NghiaBlog.Models;

namespace NghiaBlog.Areas.Admin.Controllers
{
    public class TinTucController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin/TinTuc
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                return View(db.tintucs.ToList());
            }
            else
            {
                return RedirectToAction("Login", "TrangChu");
            }
        
        }

        // GET: Admin/TinTuc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // GET: Admin/TinTuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TinTuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tieude,tomtat,noidung,img,ngaytao")] tintuc tintuc,HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Method 2 Get file details from HttpPostedFileBase class   
                    if (img != null)
                    {
                        var fileName = "";
                        //Upload File
                        if (img != null && img.ContentLength > 0)
                        {
                            
                            string path = Path.Combine(Server.MapPath("~/assets/img/"), Path.GetFileName(img.FileName));
                            fileName = Path.GetFileName(img.FileName);
                            img.SaveAs(path);
                        }
                       
                        tintuc.img = fileName;
                        tintuc.ngaytao = DateTime.Now;
                        db.tintucs.Add(tintuc);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    // ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while file uploading."; ;
                }
                db.tintucs.Add(tintuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tintuc);
        }

        // GET: Admin/TinTuc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // POST: Admin/TinTuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tieude,tomtat,noidung,img,ngaytao")] tintuc tintuc,HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Method 2 Get file details from HttpPostedFileBase class   
                    if (img != null)
                    {
                        var fileName = tintuc.img;
                        //Upload File
                        if (img != null && img.ContentLength > 0)
                        {
                            string path = Path.Combine(Server.MapPath("~/assets/img/"), Path.GetFileName(img.FileName));
                            fileName = Path.GetFileName(img.FileName);
                            img.SaveAs(path);
                        }
                        tintuc.img = fileName;

                        db.Entry(tintuc).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");

                    }
                    // ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while file uploading."; ;
                }
                db.Entry(tintuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tintuc);
        }

        // GET: Admin/TinTuc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // POST: Admin/TinTuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tintuc tintuc = db.tintucs.Find(id);
            db.tintucs.Remove(tintuc);
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
