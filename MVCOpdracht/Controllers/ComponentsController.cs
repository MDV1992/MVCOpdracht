using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MVCOpdracht.Models;
using MVCOpdracht.Models.DAL;

namespace MVCOpdracht.Controllers
{
    public class ComponentsController : Controller
    {
        private ComponentContext db = new ComponentContext();

        // GET: Components
        public ActionResult Index(string SortOrder, string componentsCategorie, string SearchString)
        {

            ViewBag.NameSortParm = string.IsNullOrEmpty(SortOrder) ? "naam_desc" : "";
            ViewBag.componentsCategorieSortParm = string.IsNullOrEmpty(SortOrder) ? "categorie_desc": "";


            var component = from c in db.Components select c;
            switch (SortOrder)
            {
                default:
                component.OrderByDescending(c => c.Naam);
                break;

                case "naam_desc" :
                component.OrderByDescending(c => c.Naam);
                break;
                
                case "categorie_desc" :
                component.OrderByDescending(c => c.Categorie);
                break;


            }


            //http://www.asp.net/mvc/overview/getting-started/introduction/adding-search

            var categorielijst = new List<string>();
            var CategerieQuery = from d in db.Components orderby d.Categorie select d.Categorie;

            categorielijst.AddRange(CategerieQuery.Distinct());
            ViewBag.componentsCategorie = new SelectList(categorielijst);

            var components = from c in db.Components select c; if (!String.IsNullOrEmpty(SearchString)) { components = components.Where(s => s.Naam.Contains(SearchString)); }
            if (!string.IsNullOrEmpty(componentsCategorie)) { components = components.Where(x => x.Categorie == componentsCategorie); } return View(components);

           // return View(db.Components.ToList());
        }

        // GET: Components/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Components.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // GET: Components/Create
        [Authorize]
        //Zorgt ervoor dat je moet inloggen.
        public ActionResult Create()
        {
            return View();
        }

        // POST: Components/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Categorie,Naam,Link,Aantal,Prijs,Aankoop")] Component component)
        {
            if (ModelState.IsValid)
            {
                db.Components.Add(component);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(component);
        }

        // GET: Components/Edit/5
        [Authorize]
        //Zorgt ervoor dat je moet inloggen.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Components.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // POST: Components/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Categorie,Naam,Link,Aantal,Prijs,Aankoop")] Component component)
        {
            if (ModelState.IsValid)
            {
                db.Entry(component).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(component);
        }

        // GET: Components/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Components.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Component component = db.Components.Find(id);
            db.Components.Remove(component);
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
