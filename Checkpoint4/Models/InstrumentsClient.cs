using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkpoint4.Models
{
    public class InstrumentsClient
    {
        public Instrument instrument { get; set; }
        public Client client { get; set; }
    }
}