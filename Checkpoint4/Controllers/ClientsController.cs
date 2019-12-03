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
//What a nice controller
namespace Checkpoint4.Controllers
{
    public class ClientsController : Controller
    {
        private BlowOutContext db = new BlowOutContext();

        // GET: Clients here is another comment.
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
            InstrumentsClient instrumentsClient = new InstrumentsClient();
            instrumentsClient.instrument = db.Instruments.Find(iTempInstID);

            return View(instrumentsClient);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstrumentsClient instrumentsClient)
        {
            if (ModelState.IsValid)
            {
                var entity = new Client()
                {
                    CliFirstName = instrumentsClient.client.CliFirstName,
                    CliLastName = instrumentsClient.client.CliLastName,
                    CliAddress = instrumentsClient.client.CliAddress,
                    CliCity = instrumentsClient.client.CliCity,
                    CliState = instrumentsClient.client.CliState,
                    CliZip = instrumentsClient.client.CliZip,
                    CliEmail = instrumentsClient.client.CliEmail,
                    CliPhone = instrumentsClient.client.CliPhone
                };

                db.Clients.Add(entity);
                db.SaveChanges();

                instrumentsClient.client = entity;
                db.SaveChanges();

                ViewBag.Sum = (Int32.Parse(instrumentsClient.instrument.InstPrice) * 18);

                ModelState.Clear();
                //go to summary and use @ViewBag.Client.CliFirstName etc
                return View("Summary", instrumentsClient);
            }

            return View(instrumentsClient);
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
