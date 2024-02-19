using PartnerWeb.Models;
using System.Collections.Generic;

namespace PartnerWeb.Services
{
    public interface IInsurancePolicyService
    {
        IEnumerable<Partner> GetAllPartners();
        void CreateInsurancePolicy(InsurancePolicy policy);
    }
}
