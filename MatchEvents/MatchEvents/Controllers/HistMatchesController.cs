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
    public class HistMatchesController : Controller
    {
        private MatchEventsDB db = new MatchEventsDB();

        // GET: HistMatches
        public async Task<ActionResult> Index()
        {
            return View(await db.HistMatches.ToListAsync());
        }

        // GET: HistMatches/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistMatch histMatch = await db.HistMatches.FindAsync(id);
            if (histMatch == null)
            {
                return HttpNotFound();
            }
            return View(histMatch);
        }

        // GET: HistMatches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistMatches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,idUser,idUserMatch,IdEvent,DataCriacao")] HistMatch histMatch)
        {
            if (ModelState.IsValid)
            {
                db.HistMatches.Add(histMatch);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(histMatch);
        }

        // GET: HistMatches/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistMatch histMatch = await db.HistMatches.FindAsync(id);
            if (histMatch == null)
            {
                return HttpNotFound();
            }
            return View(histMatch);
        }

        // POST: HistMatches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,idUser,idUserMatch,IdEvent,DataCriacao")] HistMatch histMatch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(histMatch).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(histMatch);
        }

        // GET: HistMatches/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistMatch histMatch = await db.HistMatches.FindAsync(id);
            if (histMatch == null)
            {
                return HttpNotFound();
            }
            return View(histMatch);
        }

        // POST: HistMatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HistMatch histMatch = await db.HistMatches.FindAsync(id);
            db.HistMatches.Remove(histMatch);
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
