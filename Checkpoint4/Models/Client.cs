using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Checkpoint4.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        [Required(ErrorMessage = "ClientID is required")]
        [Display(Name = "ClientID")]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string CliFirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string CliLastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string CliAddress { get; set; }
        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public string CliCity { get; set; }
        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        public string CliState { get; set; }
        [Required]
        [Display(Name = "Zip")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Zip must be 5 numbers long")]
        public int CliZip { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string CliEmail { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(\d{3}\)\s\d{3}\-\d{4}", ErrorMessage = "Phone Number should be in format (xxx) xxx-xxxx")]
        [Display(Name = "Phone")]
        public string CliPhone { get; set; }
        [Display(Name = "Instrument ID")]
        public int InstID { get; set; }
    }
}