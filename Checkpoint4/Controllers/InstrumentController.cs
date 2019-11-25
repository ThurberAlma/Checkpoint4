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
        List<Instrument> lstInt = new List<Instrument>()
        {
            new Instrument {InstID = 1, InstDesc = "TrumpetNew", InstPrice = "55", InstType = "New", InstImg = "https://images-na.ssl-images-amazon.com/images/I/71VuWpPzAuL._SX425_.jpg"},
            new Instrument {InstID = 2, InstDesc = "TrumpetOld", InstPrice = "25", InstType = "Old", InstImg = "https://www.hornhospital.com/main/wp-content/uploads/american-trumpet-42737.jpg"},
            new Instrument {InstID = 3, InstDesc = "TromboneNew", InstPrice = "60", InstType = "New", InstImg = "https://cdn.shoplightspeed.com/shops/612125/files/11137624/image.jpg"},
            new Instrument {InstID = 4, InstDesc = "TromboneOld", InstPrice = "35", InstType = "Old", InstImg = "https://i.redd.it/brgw1v7nadf11.jpg"},
            new Instrument {InstID = 5, InstDesc = "TubaNew", InstPrice = "70", InstType = "New", InstImg = "https://i.ebayimg.com/images/g/s4QAAOSwzSdbyfJW/s-l300.jpg"},
            new Instrument {InstID = 6, InstDesc = "TubaOld", InstPrice = "50", InstType = "Old", InstImg = "https://images-na.ssl-images-amazon.com/images/I/61yfRh2NC6L._SX425_.jpg"},
            new Instrument {InstID = 7, InstDesc = "FluteNew", InstPrice = "40", InstType = "New", InstImg = "https://images-na.ssl-images-amazon.com/images/I/41%2B7GConwcL._SX425_.jpg"},
            new Instrument {InstID = 8, InstDesc = "FluteOld", InstPrice = "25", InstType = "Old", InstImg = "https://www.kesslerandsons.com/wp-content/uploads/2015/11/pearl-quantz-f665-flute2.jpg"},
            new Instrument {InstID = 9, InstDesc = "ClarinetNew", InstPrice = "35", InstType = "New", InstImg = "https://www.kesslerandsons.com/wp-content/uploads/yamaha-rental-clarinet.jpg"},
            new Instrument {InstID = 10, InstDesc = "ClarinetOld", InstPrice = "27", InstType = "Old", InstImg = "https://i.redd.it/lcs6z3ue9xb31.jpg"},
            new Instrument {InstID = 11, InstDesc = "SaxophoneNew", InstPrice = "42", InstType = "New", InstImg = "https://i.ebayimg.com/images/g/yv4AAMXQVs1Rjc8D/s-l300.jpg"},
            new Instrument {InstID = 12, InstDesc = "SaxophoneOld", InstPrice = "30", InstType = "Old", InstImg = "https://storage.bhs1.cloud.ovh.net/v1/AUTH_e7d15450bedd40b9b599e075527df3cb/jackson/fNew_ALLARIA_BN360_Alto_Saxophone__ReedsA_5abebdb7642ea.jpg"}
        };

        // GET: Instrument
        public ActionResult ShowInstrument(int iID)
        {
            Instrument oInst = lstInt.Find(x => x.InstID == iID);
            return View(oInst);
        }
    }
}