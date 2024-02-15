using Dapper;
using PartnerWeb.DataAccess;
using PartnerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartnerWeb.Controllers
{
    public class InsurancePolicyController : Controller
    {
        // GET: InsurancePolicy
        [HttpGet]
        public ActionResult Create()
        {
            IEnumerable<Partner> enumerable = DapperORM.ReturnList<Partner>("AllPartners");
            List<SelectListItem> partnerItems = enumerable.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = $"{p.FirstName} {p.LastName}" }).ToList();
            ViewBag.Partners = partnerItems;
            return View();
        }

        [HttpPost]
        public ActionResult Create(InsurancePolicy policy)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PolicyNumber", policy.PolicyNumber);
            param.Add("@PolicyPrice", policy.PolicyPrice);
            param.Add("@partnerId", policy.PartnerId);
            DapperORM.ExecuteWithoutReturn("PolicyAdd", param);
            return RedirectToAction("Index", "Partner");
        }
    }
}