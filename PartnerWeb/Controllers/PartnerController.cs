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
    public class PartnerController : Controller
    {
        // GET: Partner
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<Partner>("AllPartners"));
        }

        [HttpGet]
        public ActionResult PartnerAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PartnerAdd(Partner partner)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@FirstName", partner.FirstName);
            param.Add("@LastName", partner.LastName);
            param.Add("@Address", partner.Address);
            param.Add("@PartnerNumber", partner.PartnerNumber);
            param.Add("@CroatianPIN", partner.CroatianPIN);
            param.Add("@PartnerTypeId", partner.PartnerTypeId);
            param.Add("@CreateByUser", partner.CreateByUser);
            param.Add("@IsForegin", partner.IsForeign.HasValue ? partner.IsForeign : false);
            param.Add("@ExternalCode", partner.ExternalCode);
            param.Add("@Gender", partner.Gender);
            DapperORM.ExecuteWithoutReturn("PartnerAdd", param);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            return View(DapperORM.ReturnList<Partner>("GetPartnerById", param).FirstOrDefault<Partner>());
        }

        [HttpPost]
        public ActionResult Edit(Partner partner)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", partner.Id);
            param.Add("@FirstName", partner.FirstName);
            param.Add("@LastName", partner.LastName);
            param.Add("@Address", partner.Address);
            param.Add("@PartnerNumber", partner.PartnerNumber);
            param.Add("@CroatianPIN", partner.CroatianPIN);
            param.Add("@PartnerTypeId", partner.PartnerTypeId);
            param.Add("@CreateByUser", partner.CreateByUser);
            param.Add("@IsForegin", partner.IsForeign.HasValue ? partner.IsForeign : false);
            param.Add("@ExternalCode", partner.ExternalCode);
            param.Add("@Gender", partner.Gender);
            DapperORM.ExecuteWithoutReturn("PartnerUpdate", param);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            DapperORM.ExecuteWithoutReturn("DeletePartnerById", param);
            return RedirectToAction("Index");
        }
    }
}