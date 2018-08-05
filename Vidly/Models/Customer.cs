using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Migrations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]      // nie będzie dalej nulowalny
        [StringLength(255)]     // Max 255 znakow
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Memberhip Type")]
        public byte MembershipTypeId { get; set; }
        
        [Display(Name = "Date of birth")] // Trzeba zawsze rekompilowac kod po zmianie
        public DateTime? Birthdate { get; set; }
    }
}