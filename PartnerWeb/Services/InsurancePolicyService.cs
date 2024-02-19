using Dapper;
using PartnerWeb.DataAccess;
using PartnerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartnerWeb.Services
{
    public class InsurancePolicyService : IInsurancePolicyService
    {
        public IEnumerable<Partner> GetAllPartners()
        {
            return DapperORM.ReturnList<Partner>("AllPartners");
        }

        public void CreateInsurancePolicy(InsurancePolicy policy)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PolicyNumber", policy.PolicyNumber);
            param.Add("@PolicyPrice", policy.PolicyPrice);
            param.Add("@partnerId", policy.PartnerId);
            DapperORM.ExecuteWithoutReturn("PolicyAdd", param);
        }
    }
}