using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.EF.Context;
using Domain.GerenciamentoCursosLGroup.Entities;

namespace Apresentation.Mvc.Empty.Controllers
{

    //Itens criados via scaffold
    //Quando definimos no Authorize uma role, apenas permitimos acesso a quem per-
    //tence a role
    [Authorize(Roles = "Administrador")]
    public class AlunoController : Controller
    {
        private GerenciamentoCursoLGroupContext db = new GerenciamentoCursoLGroupContext();

        // GET: Aluno
        public ActionResult Index()
        {
            return View(db.Aluno.ToList());
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoEntity alunoEntity = db.Aluno.Find(id);
            if (alunoEntity == null)
            {
                return HttpNotFound();
            }
            return View(alunoEntity);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataCriacao")] AlunoEntity alunoEntity)
        {
            if (ModelState.IsValid)
            {
                db.Aluno.Add(alunoEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alunoEntity);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoEntity alunoEntity = db.Aluno.Find(id);
            if (alunoEntity == null)
            {
                return HttpNotFound();
            }
            return View(alunoEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataCriacao")] AlunoEntity alunoEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunoEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alunoEntity);
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoEntity alunoEntity = db.Aluno.Find(id);
            if (alunoEntity == null)
            {
                return HttpNotFound();
            }
            return View(alunoEntity);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlunoEntity alunoEntity = db.Aluno.Find(id);
            db.Aluno.Remove(alunoEntity);
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
