using PartnerWeb.Utils;
using System;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage ="You must choose partner.")]
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }

        public static bool IsValid(InsurancePolicy policy)
        {
            bool isPolicyNumberValid = !string.IsNullOrEmpty(policy.PolicyNumber) &&
                               policy.PolicyNumber.Length >= 10 &&
                               policy.PolicyNumber.Length <= 15;

            bool isPartnerIdValid = policy.PartnerId > 0;

            return isPolicyNumberValid &&
                   isPartnerIdValid;
        }

    }
}