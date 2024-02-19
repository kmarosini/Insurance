using PartnerWeb.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

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
        [RegularExpression(@"^\d{20}$", ErrorMessage = "PartnerNumber must be a valid 20-digit number.")]
        public string PartnerNumber { get; set; }
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

        public static bool IsValid(Partner partner)
        {
            bool isFirstNameValid = ValidatorUtil.IsValidName(partner.FirstName);
            bool isLastNameValid = ValidatorUtil.IsValidName(partner.LastName);
            bool isEmailValid = ValidatorUtil.IsValidEmail(partner.CreateByUser);
            bool isPartnerNumberValid = ValidatorUtil.IsValidPartnerNumber(partner.PartnerNumber);
            bool isPartnerTypeValid = ValidatorUtil.IsValidPartnerType((int)partner.PartnerTypeId);
            bool isIsForeignValid = ValidatorUtil.IsValidIsForeign(partner.IsForeign);
            bool isExternalCodeValid = ValidatorUtil.IsValidExternalCode(partner.ExternalCode);
            bool isGenderValid = ValidatorUtil.IsValidGender(partner.Gender);

            return isFirstNameValid &&
                   isLastNameValid &&
                   isEmailValid &&
                   isPartnerNumberValid &&
                   isPartnerTypeValid &&
                   isIsForeignValid &&
                   isExternalCodeValid &&
                   isGenderValid;
        }
    }
}