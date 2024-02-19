using PartnerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerWeb.Services
{
    public interface IInsurancePolicyService
    {
        IEnumerable<Partner> GetAllPartners();
        void CreateInsurancePolicy(InsurancePolicy policy);
    }
}
