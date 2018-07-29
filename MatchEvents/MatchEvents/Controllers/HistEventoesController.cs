using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MatchEvents.Models;

namespace MatchEvents.Controllers
{
    public class HistEventoesController : Controller
    {
        private MatchEventsDB db = new MatchEventsDB();

        // GET: HistEventoes
        public async Task<ActionResult> Index()
        {
            return View(await db.HistEventoes.ToListAsync());
        }

        // GET: HistEventoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistEvento histEvento = await db.HistEventoes.FindAsync(id);
            if (histEvento == null)
            {
                return HttpNotFound();
            }
            return View(histEvento);
        }

        // GET: HistEventoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistEventoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,idEvento,IdUser,Status,DataCriacao")] HistEvento histEvento)
        {
            if (ModelState.IsValid)
            {
                db.HistEventoes.Add(histEvento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(histEvento);
        }

        // GET: HistEventoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistEvento histEvento = await db.HistEventoes.FindAsync(id);
            if (histEvento == null)
            {
                return HttpNotFound();
            }
            return View(histEvento);
        }

        // POST: HistEventoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,idEvento,IdUser,Status,DataCriacao")] HistEvento histEvento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(histEvento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(histEvento);
        }

        // GET: HistEventoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistEvento histEvento = await db.HistEventoes.FindAsync(id);
            if (histEvento == null)
            {
                return HttpNotFound();
            }
            return View(histEvento);
        }

        // POST: HistEventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HistEvento histEvento = await db.HistEventoes.FindAsync(id);
            db.HistEventoes.Remove(histEvento);
            await db.SaveChangesAsync();
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
