using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace WebForm.Generator.Model
{
    internal class FormContent
    {
        public string DocType { get; set; }
        public string Version { get; set; }
        public string Organization { get; set; }

        public InputRules InputRules { get; set; }
        public Pages Pages { get; set; }
        public Attachments Attachments { get; set; }
        public Datas AllDataFields { get; set; }
        public Metas Metas { get; set; }
        public Vars Vars { get; set; }
        public FormChecks FormChecks { get; set; }
        public PageChecks PageChecks { get; set; }
        public FieldChecks FieldChecks { get; set; }
        public FieldCalcs FieldCalcs { get; set; }

        internal FormContent(XmlElement form)
        {
            this.AllDataFields = new Datas();

            var docInfo = form.OwnerDocument.DocumentElement.SelectSingleNode("/FILE/HEAD/DOCINFO");

            this.DocType = docInfo.Attributes["name"].Value;
            this.Version = docInfo.Attributes["ver"].Value;
            this.Organization = docInfo.Attributes["org"].Value;

            // input szabályok
            this.InputRules = new InputRules(this, form.SelectNodes("GUI/INPUTRULES/INPUTRULE").OfType<XmlElement>().ToList());

            // a csatolmány metaadatok betöltése
            this.Attachments = new Attachments(form.SelectNodes("Attachments/Attachment").OfType<XmlElement>().ToList());

            // lapok
            this.Pages = new Pages(this, form.SelectNodes("GUI/PAGES/PAGE").OfType<XmlElement>().ToList());

            // meták
            this.Metas = new Metas(this, form.SelectNodes("METAS/META").OfType<XmlElement>().ToList());

            // vars
            this.Vars = new Vars(this, form.SelectNodes("CALCS/VARS/VAR").OfType<XmlElement>().ToList());
            this.Vars.CalcJS();

            // formcheck
            this.FormChecks = new FormChecks(this, form.SelectNodes("CALCS/FORMCALCS/CALC[@on_event='form_check']").OfType<XmlElement>().ToList());

            // pagecheck
            this.PageChecks = new PageChecks(this, form.SelectNodes("CALCS/PAGECALCS/PAGE/CALC[@on_event='page_check']").OfType<XmlElement>().ToList());

            // fieldcheck
            this.FieldChecks = new FieldChecks(this, form.SelectNodes("CALCS/FIELDCALCS/FIELDCALC/CALC[@on_event='field_check']").OfType<XmlElement>().ToList());

            // fieldcalc
            this.FieldCalcs = new FieldCalcs(this, form.SelectNodes("CALCS/FIELDCALCS/FIELDCALC/CALC[@on_event='field_calc']").OfType<XmlElement>().ToList());
        }

        internal void BeginOutput(StreamWriter sw)
        {
//            sw.WriteLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">");
//            sw.WriteLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"en\">");
//            sw.WriteLine("<head>");
//            sw.WriteLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"../../../css/jquery.ui.all.css\" />");
//            sw.WriteLine("<script type=\"text/javascript\" src=\"../../../jquery-1.4.4.min.js\"></script>");
//            sw.WriteLine("<script type=\"text/javascript\" src=\"../../../jquery-ui-1.8.9.custom.min.js\"></script>");
//            sw.WriteLine("<script type=\"text/javascript\" src=\"../../../jquery.ui.datepicker-hu.js\"></script>");
//            sw.WriteLine("<script type=\"text/javascript\" src=\"../../../jquery.keyfilter-1.7.min.js\"></script>");
////            sw.WriteLine("<script type=\"text/javascript\" src=\"../../../jquery.meio.mask.min.js\"></script>");
//            sw.WriteLine("<script type=\"text/javascript\" src=\"../../../jquery.maskedinput.js\"></script>");
//            sw.WriteLine("<script type=\"text/javascript\" src=\"../../../MicrosoftAjax.js\"></script>");
//            sw.WriteLine("<script type=\"text/javascript\" src=\"../../../abev_functions.js\"></script>");

//!!!!!!
//            sw.WriteLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"form.css\" />");
//            sw.WriteLine("<script type=\"text/javascript\" src=\"calculations.js\"></script>");
//!!!!!!
            
//            sw.WriteLine("</head>");
//            sw.WriteLine("<body>");
            sw.WriteLine("<a href=\"#\" onclick=\"return formCheck();\">Form Check</a>");
            sw.WriteLine("<div id=\"errors\"></div>");
            sw.WriteLine("<div id=\"pages\">");
            sw.WriteLine("  <ul>");
            foreach (var p in this.Pages)
            {
                sw.WriteLine("    <li><a href=\"#{0}\">{1}</a></li>", p.UIId, p.Title);
            }
            sw.WriteLine("  </ul>");
        }

        internal void EndOutput(StreamWriter sw)
        {
            var yp1 = DateTime.Today.Year + 1;

            sw.WriteLine("</div>");

            sw.WriteLine("<script type=\"text/javascript\">");
            sw.WriteLine(" $(document).ready(function() {");
            sw.WriteLine("   $(\"#pages\").tabs();");

            //sw.WriteLine("   var fldType = new Array();");
            foreach (var d in this.AllDataFields)
            {
                sw.WriteLine("   fldI[\"{0}\"] = {{T:{1},S:{2},O:{3},P:{4},N:'{5}'}};", d.FID, (int)d.FieldTypeBase, d.Meta.Row, d.Meta.Col, d.Page.Id, d.Meta.Name);
            }
            sw.WriteLine();
            sw.WriteLine("  initFormFields();");

            foreach (var dd in this.AllDataFields.Where(d => d is DataDate && d.HtmlVisible && !d.Readonly))
            {
                //sw.WriteLine(" $('#{0}').datepicker({{ yearRange: '1950:{1}', changeYear: true, changeMonth:true }});", dd.FID, yp1);
            }

            foreach (var d in this.AllDataFields.Where(d => !(d is DataCheck) && d.HtmlVisible && !d.Readonly))
            {
                if (d.Meta.Irids.Count == 1)
                {
                    var irid = d.Meta.Irids[0];
                    var iRule = this.InputRules.SingleOrDefault(ir => ir.Irid == irid);
                    if (iRule != null && iRule.IsValid)
                    {
                        sw.WriteLine(" $('#{0}').keyfilter({1});", d.FID, iRule.JSRule);
                    }
                }
            }

            foreach (var d in this.AllDataFields.Where(d => d is IMaskable))
            {
                var im = d as IMaskable;
                if (im.JSMask != null)
                {
                    if (d is DataDate)
                    {
                        sw.WriteLine(" $('#{0}').mask('{1}');", d.FID, im.JSMask);
                    }
                    else
                    {
                        var cnt = im.JSMask.Count(c => char.IsDigit(c) || c == '#' || c== '*');
                        sw.WriteLine("$('#{0}').attr('maxlength', {1});", d.FID, cnt);
                    }

            //        if((d.Meta.FieldType & MetaFieldType.Number) == MetaFieldType.Number)
            //        {
            //            string mask = im.JSMask.Replace(".", ""); // a potozott szám marhaság
            //            sw.WriteLine(" $('#{0}').mask('{1}');", d.FID, mask);
            //        }
                } 
            }

            sw.WriteLine("  pageCalc();");
            sw.WriteLine("  attachCalculators();");
            sw.WriteLine(" });");
            sw.WriteLine("</script>");
//            sw.WriteLine("</body>");
//            sw.WriteLine("</html>");
        }
    }

    public static class StringExt
    {
        public static string ToPLName(this string val)
        {
            string ret = string.Empty;
            foreach (var v in val)
            {
                if (char.IsLetterOrDigit(v))
                {
                    ret += v;
                }
                else
                {
                    ret += "_";
                }
            }
            return ret;
        }
    }
}
