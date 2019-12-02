using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Checkpoint4.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        [Required(ErrorMessage = "InstID is required")]
        [Display(Name = "Instrument ID")]
        public int InstID { get; set; }

        [Required(ErrorMessage = "InstDesc is required")]
        [Display(Name = "Instrument Name")]
        public string InstDesc { get; set; }

        [Required(ErrorMessage = "Instrument Type is required")]
        [Display(Name = "Instrument Type")]
        public string InstType { get; set; }

        [Required(ErrorMessage = "InstPrice is required")]
        [Display(Name = "Instrument Price")]
        public string InstPrice { get; set; }

        [Display(Name = "Client ID")]
        public int? ClientId { get; set; }

        [Display(Name = "Image")]
        public string InstImg { get; set; }
    }
}