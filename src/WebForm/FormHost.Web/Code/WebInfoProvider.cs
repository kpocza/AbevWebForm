using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FormHost.Model.Forms;
using FormHost.Model.Interfaces;
using System.IO;

namespace FormHost.Web.Code
{
    public class WebInfoProvider : IInfoProvider
    {
        public WebDTVContent GetFormDataBy(DocTypeVersion dtv)
        {
            var org = dtv.DocumentType.Organization.Name;
            var docType = dtv.DocumentType.Name;
            var version = dtv.VersionString;
            var rootPath = HttpContext.Current.Request.ApplicationPath.TrimEnd('/');

            var formRoot = string.Format("{0}/Templates/{1}/{2}/{3}", rootPath, org, docType, version);

            return new WebDTVContent
            {
                DocTypeVersion = dtv,
                CSSUrl = string.Format("{0}/form.css", formRoot),
                JavaScriptUrl = string.Format("{0}/calculations.js", formRoot),
                HTML = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath(string.Format("{0}/form.html", formRoot)))
            };
        }
    }
}