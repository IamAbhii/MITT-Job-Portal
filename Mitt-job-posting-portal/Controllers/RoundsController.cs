﻿using Mitt_job_posting_portal.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Mitt_job_posting_portal.Controllers
{
  [Authorize(Roles = "Instructor, Admin")]
  public class RoundsController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Rounds
    public ActionResult Index()
    {
      return View(db.Round.ToList());
    }

    // GET: Rounds/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Round round = db.Round.Find(id);
      if (round == null)
      {
        return HttpNotFound();
      }
      return View(round);
    }

    // GET: Rounds/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Rounds/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,IntakeTitle,InternshipStartDate,InternshipEndDate")] Round round)
    {
      if (ModelState.IsValid)
      {
        db.Round.Add(round);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(round);
    }

    // GET: Rounds/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Round round = db.Round.Find(id);
      if (round == null)
      {
        return HttpNotFound();
      }
      return View(round);
    }

    // POST: Rounds/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,IntakeTitle,InternshipStartDate,InternshipEndDate")] Round round)
    {
      if (ModelState.IsValid)
      {
        db.Entry(round).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(round);
    }

    // GET: Rounds/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Round round = db.Round.Find(id);
      if (round == null)
      {
        return HttpNotFound();
      }
      return View(round);
    }

    // POST: Rounds/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Round round = db.Round.Find(id);
      db.Round.Remove(round);
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
