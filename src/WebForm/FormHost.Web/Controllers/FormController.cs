using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormHost.Web.Models;
using FormHost.Model;
using FormHost.Model.Fillings;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FormHost.Web.Controllers
{
    public class FormController : Controller
    {
        //
        // GET: /Form/

        public ActionResult Index(int Id, int? fillId)
        {
            var templateService = ServiceFactory.GetTemplateService();
            var content = templateService.GetContent(Id);

            var formModel = new FormModel
            {
                NewForm = !fillId.HasValue,
                FillToLoad = fillId.HasValue ? fillId.Value : 0,
                Content = content
            };

            return View(formModel);
        }

        public JavaScriptResult Empty()
        {
            var initFunc = "function initFormFields() {}";
            return JavaScript(initFunc);
        }

        public JavaScriptResult Field(int Id)
        {
            var fillService = ServiceFactory.GetFillService();
            var fill = fillService.GetFillContent(Id);

            using (MemoryStream stream = new MemoryStream(fill.Content.EnyK))
            {
                BinaryFormatter objFormatter = new BinaryFormatter();
                var dict = (Dictionary<string, string>)objFormatter.Deserialize(stream);
                var sb = new StringBuilder();
                sb.AppendLine("function initFormFields() {");
                foreach (var d in dict)
                {
                    sb.AppendLine(string.Format("initSingleField('{0}', '{1}');", d.Key, d.Value));
                }
                sb.AppendLine("}");
                return JavaScript(sb.ToString());
            }
        }

        public ActionResult Save(int Id, int ?fillId, FormCollection fc)
        {
            var dict = new Dictionary<string, string>();
            foreach (var key in fc.AllKeys)
            {
                dict.Add(key, fc[key].ToString());
            }

            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter objFormatter = new BinaryFormatter();
                objFormatter.Serialize(stream, dict);
                var data = stream.ToArray();

                var fillService = ServiceFactory.GetFillService();
                Fill fill = null;
                if (!fillId.HasValue)
                {
                    fill = new Fill
                    {
                        StartVersion = new Model.Forms.DocTypeVersion { Id = Id },
                        Content = new FillContent { EnyK = data },
                    };
                }
                else
                {
                    fill = new Fill
                    {
                        Id = fillId.Value,
                        Content = new FillContent { EnyK = data },
                    };
                }
                fillService.Save(fill);
            }

            return RedirectToAction("Index", new { Id = Id });
        }
    }
}
