﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliverySite.Models;

namespace DeliverySite.Controllers
{
    public class CommandsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Commands
        public ActionResult Index()
        {
            var commands = db.Commands.Include(c=> c.Client).Include(c => c.Manufacturer).Include(c => c.Product).Include(c => c.Status);
            return View(commands.ToList());
        }

        // GET: Commands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Command command = db.Commands.Find(id);
            if (command == null)
            {
                return HttpNotFound();
            }
            return View(command);
        }

        // GET: Commands/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.DeliveryManId = new SelectList(db.DeliveryMen, "Id", "DeliveryManName");
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "ManufacturerName");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName");
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Id");
            return View();
        }

        // POST: Commands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientId,ManufacturerId,ProductId,StatusId,DeliveryManId,SumCommand")] Command command)
        {
            if (ModelState.IsValid)
            {
                db.Commands.Add(command);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Users, "Id", "UserName",command.ClientId);
            
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "ManufacturerName", command.ManufacturerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", command.ProductId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Id", command.StatusId);
            return View(command);
        }

        // GET: Commands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Command command = db.Commands.Find(id);
            if (command == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Users, "Id", "UserName",command.ClientId);
            
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "ManufacturerName", command.ManufacturerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", command.ProductId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Id", command.StatusId);
            return View(command);
        }

        // POST: Commands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientId,ManufacturerId,ProductId,StatusId,DeliveryManId,SumCommand")] Command command)
        {
            if (ModelState.IsValid)
            {
                db.Entry(command).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Users, "Id", "UserName", command.ClientId);
            
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "ManufacturerName", command.ManufacturerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", command.ProductId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Id", command.StatusId);
            return View(command);
        }

        // GET: Commands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Command command = db.Commands.Find(id);
            if (command == null)
            {
                return HttpNotFound();
            }
            return View(command);
        }

        // POST: Commands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Command command = db.Commands.Find(id);
            db.Commands.Remove(command);
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
