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
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required]
        public decimal PartnerNumber { get; set; }
        public string CroatianPIN { get; set; }
        [Required]
        public PartnerType PartnerTypeId { get; set; }
        public DateTime? CreatedAtUtc { get; set; }
        [Required]
        public string CreateByUser { get; set; }
        [Required]
        public bool IsForeign { get; set; }
        [StringLength(20, MinimumLength = 10)]
        public string ExternalCode { get; set; }
        [Required]
        public char Gender { get; set; }
    }
}