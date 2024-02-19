using PartnerWeb.DataAccess;
using PartnerWeb.Models;
using PartnerWeb.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PartnerWeb.Controllers
{
    public class PartnerController : Controller
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        // GET: Partner
        public ActionResult Index()
        {
            ViewBag.NewRecordId = TempData["NewRecord"];

            return View(DapperORM.ReturnList<Partner>("AllPartners"));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.PartnerTypes = new SelectList(Enum.GetValues(typeof(Partner.PartnerType)).Cast<Partner.PartnerType>().Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }), "Value", "Text");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Partner partner)
        {
            _partnerService.CreatePartner(partner);
            TempData["NewRecord"] = partner.ExternalCode;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var partner = _partnerService.GetPartnerById(id);
            ViewBag.PartnerTypes = new SelectList(Enum.GetValues(typeof(Partner.PartnerType)).Cast<Partner.PartnerType>().Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }), "Value", "Text");

            return View(partner);
        }

        [HttpPost]
        public ActionResult Edit(Partner partner)
        {
            _partnerService.UpdatePartner(partner);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            _partnerService.DeletePartner(id);
            return RedirectToAction("Index");
        }
    }
}