using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartnerWeb.Models
{
    public class Partner
    {
        public enum PartnerType
        {
            Personal = 1,
            Legal = 2
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "* required")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "* minimum length is 2 and maximum length is 255")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "* required")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "* minimum length is 2 and maximum length is 255")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "* required")]
        public int PartnerNumber { get; set; }
        public string CroatianPIN { get; set; }
        [Required(ErrorMessage = "* required")]
        public PartnerType PartnerTypeId { get; set; }
        public DateTime? CreatedAtUtc { get; set; }
        [Required(ErrorMessage = "* required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string CreateByUser { get; set; }
        [Required(ErrorMessage = "* required")]
        public bool? IsForeign { get; set; }
        [StringLength(20, MinimumLength = 10, ErrorMessage = "* minimum length is 10 and maximum length is 20")]
        public string ExternalCode { get; set; }
        [Required(ErrorMessage = "* required")]
        public char Gender { get; set; }
        public int PolicyCount { get; set; }
        public decimal TotalPolicyAmount { get; set; }
    }
}