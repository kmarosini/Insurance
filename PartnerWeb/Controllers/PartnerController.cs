using PartnerWeb.DataAccess;
using PartnerWeb.Models;
using PartnerWeb.Services;
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
            return View(DapperORM.ReturnList<Partner>("AllPartners"));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Partner partner)
        {
            _partnerService.CreatePartner(partner);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var partner = _partnerService.GetPartnerById(id);
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