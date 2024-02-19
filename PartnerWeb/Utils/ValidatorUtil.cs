using PartnerWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartnerWeb.Utils
{
    public class ValidatorUtil
    {
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            string namePattern = @"^[a-zA-Z-']{2,255}$";
            return System.Text.RegularExpressions.Regex.IsMatch(name, namePattern);
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
        }

        public static bool IsValidPartnerNumber(string partnerNumber)
        {
            if (string.IsNullOrEmpty(partnerNumber))
            {
                return false;
            }

            string partnerNumberPattern = @"^\d{20}$";
            return System.Text.RegularExpressions.Regex.IsMatch(partnerNumber, partnerNumberPattern);
        }

        public static bool IsValidPartnerType(int partnerTypeId)
        {
            int[] allowedIds = { 1, 2 };
            return System.Array.Exists(allowedIds, id => id == partnerTypeId);
        }

        public static bool IsValidIsForeign(bool? isForeign)
        {
            return isForeign.HasValue;
        }

        public static bool IsValidExternalCode(string externalCode)
        {
            return !string.IsNullOrEmpty(externalCode) && externalCode.Length >= 10 && externalCode.Length <= 20;
        }

        public static bool IsValidGender(char gender)
        {
            char[] allowedGenders = { 'M', 'F' };
            return System.Array.Exists(allowedGenders, g => g == gender);
        }

        public static bool IsValidPolicyNumber(InsurancePolicy policy)
        {
            return !string.IsNullOrEmpty(policy.PolicyNumber) &&
                    policy.PolicyNumber.Length >= 10 &&
                    policy.PolicyNumber.Length <= 15;
        }

        public static bool IsValidPolicyPrice(decimal policyPrice)
        {
            return policyPrice > 0.01m;
        }

        public static bool IsValidPartnerId(InsurancePolicy policy)
        {
            return policy.PartnerId > 0;
        }
    }
}