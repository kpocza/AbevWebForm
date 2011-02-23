using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FormHost.Model.Forms;

namespace FormHost.Web.Models
{
    public class HomeNewFormModel
    {
        public bool OrganizationsView { get; set; }

        public Organizations Organizations { get; set; }
        public DocTypeVersions DocTypeVersions { get; set; }
    }
}