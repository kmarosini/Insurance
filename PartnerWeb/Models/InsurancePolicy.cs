using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartnerWeb.Models
{
    public class InsurancePolicy
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "PolicyNumber is required.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "PolicyNumber must be between 10 and 15 characters.")]
        public string PolicyNumber { get; set; }

        [Required(ErrorMessage = "PolicyPrice is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "PolicyPrice must be greater than 0.")]
        public decimal PolicyPrice { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }


    }
}