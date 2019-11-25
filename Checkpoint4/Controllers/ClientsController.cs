using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Checkpoint4.DAL;
using Checkpoint4.Models;

namespace Checkpoint4.Controllers
{
    public class ClientsController : Controller
    {
        private BlowOutContext db = new BlowOutContext();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create(int iTempInstID)
        {
            ViewBag.TempInstId = iTempInstID;
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,CliFirstName,CliLastName,CliAddress,CliCity,CliState,CliZip,CliEmail,CliPhone,InstID")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                Instrument Instrument = db.Instruments.Find(client.InstID);
                Instrument.ClientId = client.ClientId;
                db.SaveChanges();
                //I included Instrument ID in the model.  However you did it, set an Instrument object
                //  equal to the instrument that has your InstID  VVVVVVV
                Instrument instrument = db.Instruments.Find(client.InstID);
                //set a client object to the one you're currently working with
                Client myClient = db.Clients.Find(client.ClientId);
                //put both of those objects in the viewbag
                ViewBag.Inst = instrument;
                ViewBag.Sum = (Int32.Parse(instrument.InstPrice) * 18);
                ViewBag.Client = myClient;
                //go to summary and use @ViewBag.Client.CliFirstName etc
                return View("Summary", myClient);
            }

            return View(client);
        }

        public ActionResult Summary(Client oClient)
        {
            return View(oClient);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,CliFirstName,CliLastName,CliAddress,CliCity,CliState,CliZip,CliEmail,CliPhone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
