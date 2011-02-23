using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormHost.Model;
using FormHost.Web.Models;

namespace FormHost.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelNew(int? Id)
        {
            var templateService = ServiceFactory.GetTemplateService();
            if (!Id.HasValue)
            {
                var hnfm = new HomeNewFormModel
                {
                    OrganizationsView = true,
                    Organizations = templateService.ListOrganizations(),
                };
                return View(hnfm);
            }
            else
            {
                var hnfm = new HomeNewFormModel
                {
                    OrganizationsView = false,
                    DocTypeVersions = templateService.ListLastDocVersionsOfOrganization(new Model.Forms.Organization { Id =  Id.Value }),
                };
                return View(hnfm);
            }
        }

        public ActionResult SelEdit()
        {
            var hsm = new HomeSelModel();
            var fillService = ServiceFactory.GetFillService();
            hsm.Fills = fillService.ListFills();
            return View(hsm);
        }
    }
}
