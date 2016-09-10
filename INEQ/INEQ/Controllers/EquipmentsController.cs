using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INEQ.DAL;
using INEQ.Models;

namespace INEQ.Controllers
{
    public class EquipmentsController : Controller
    {
        private INEQContext db = new INEQContext();

        // GET: Equipments
        public ActionResult Index()
        {
            var equipments = db.Equipments.Include(e => e.Brand).Include(e => e.EquipmentType).Include(e => e.Model).Include(e => e.Status).Include(e => e.Warehouse);
            return View(equipments.ToList());
        }

        // GET: Equipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // GET: Equipments/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Description");
            ViewBag.EquipmentTypeId = new SelectList(db.EquipmentTypes, "Id", "Description");
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Description");
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Description");
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "Description");
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EquipmentTypeId,ModelId,BrandId,StatusId,WarehouseId,EntryDate,Serie,SofttekId,Active")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Equipments.Add(equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Description", equipment.BrandId);
            ViewBag.EquipmentTypeId = new SelectList(db.EquipmentTypes, "Id", "Description", equipment.EquipmentTypeId);
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Description", equipment.ModelId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Description", equipment.StatusId);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "Description", equipment.WarehouseId);
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Description", equipment.BrandId);
            ViewBag.EquipmentTypeId = new SelectList(db.EquipmentTypes, "Id", "Description", equipment.EquipmentTypeId);
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Description", equipment.ModelId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Description", equipment.StatusId);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "Description", equipment.WarehouseId);
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EquipmentTypeId,ModelId,BrandId,StatusId,WarehouseId,EntryDate,Serie,SofttekId,Active")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Description", equipment.BrandId);
            ViewBag.EquipmentTypeId = new SelectList(db.EquipmentTypes, "Id", "Description", equipment.EquipmentTypeId);
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Description", equipment.ModelId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Description", equipment.StatusId);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "Description", equipment.WarehouseId);
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipments.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipment equipment = db.Equipments.Find(id);
            db.Equipments.Remove(equipment);
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
