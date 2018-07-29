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
using MatchEvents.ViewModel;

namespace MatchEvents.Controllers
{
    public class UsuariosController : Controller
    {
        private MatchEventsDB db = new MatchEventsDB();

        // GET: Usuarios/Create
        public ActionResult Registrar()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registrar([Bind(Include = "id,Nome,Telefone,Sexo,Idade,Senha,DataCriacao")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind(Include = "Email,Senha")] LoginViewsModel login)
        {
            if (ModelState.IsValid)
            {
                if (login == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    var user = await db.Usuarios.FirstOrDefaultAsync(l => l.Email == login.email && l.Senha == login.senha);

                    if (user == null)
                    {
                        return HttpNotFound();
                    }
                }

               
                return RedirectToAction("Index","Eventoes");
            }

            return View();
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
