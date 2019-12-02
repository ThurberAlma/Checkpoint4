using Checkpoint4.DAL;
using Checkpoint4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Checkpoint4.Controllers
{
    public class InstrumentController : Controller
    {
        BlowOutContext db = new BlowOutContext();

        

        // GET: Instrument
        public ActionResult ShowInstrument(int iID)
        {
            Instrument oInst = db.Instruments.Find(iID);
            return View(oInst);
        }
    }
}