using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebForm.Generator.Model;
using System.IO;

namespace WebForm.Generator.Html
{
    internal class CalcGenerator : BaseGenerator
    {
        internal CalcGenerator(FormContent formContent, string outDir)
            : base(formContent, outDir)
        {
        }

        internal void Do()
        {
            Directory.CreateDirectory(OutputDirectory);

            var sw = new StreamWriter(Path.Combine(OutputDirectory, "calculations.js"), false, Encoding.UTF8);

            sw.WriteLine("/* variables */");
            foreach (var v in this.FormContent.Vars.Where(c => c.Resolved))
            {
                v.WriteFunc(sw);
            }

            sw.WriteLine("/* field calculations */");
            foreach (var fcalc in this.FormContent.FieldCalcs.Where(c => c.HtmlVisible && c.Resolved))
            {
                fcalc.WriteFunc(sw);
            }

            sw.WriteLine("/* field check functions */");
            foreach (var fc in this.FormContent.FieldChecks.Where(c => c.HtmlVisible && c.Resolved))
            {
                fc.WriteFunc(sw);
                sw.WriteLine("function FldAlert{0}(fid, single) {{", fc.CalcId);
                sw.WriteLine("    if(!{0}()) {{", fc.CalcId);
                sw.WriteLine("      showErr(fid, \"{0}\", single);", fc.JSMsg);
                sw.WriteLine("    }");
                sw.WriteLine("}");
            }

            sw.WriteLine("/* page check functions */");
            foreach (var fcalc in this.FormContent.PageChecks.Where(c => c.HtmlVisible && c.Resolved))
            {
                fcalc.WriteFunc(sw);
            }

            sw.WriteLine("/* form check functions */");
            foreach (var fcalc in this.FormContent.FormChecks.Where(c => c.HtmlVisible && c.Resolved))
            {
                fcalc.WriteFunc(sw);
            }

            sw.WriteLine("/* page visibility calculation functions */");
            sw.WriteLine("function pageCalc(){");
            foreach (var p in this.FormContent.Pages)
            {
                sw.WriteLine("  pgI[{0}] = true;", p.Id);
            }
            foreach (var p in this.FormContent.PageChecks.Where(c => c.HtmlVisible && c.Resolved))
            {
                    var idx = this.FormContent.Pages.IndexOf(p.Page);
                    sw.WriteLine("  var pEnab = {0}();", p.CalcId);
                    sw.WriteLine("  $(\"#pages\").tabs(pEnab ? 'enable' : 'disable', {0});", idx);
                    sw.WriteLine("  pgI[{0}] = pEnab;", p.Page.Id);
            }
            sw.WriteLine("}");

            sw.WriteLine("/* form fields relation check function */");
            sw.WriteLine("function formCheck(){");
            sw.WriteLine("    clearErr();");
            foreach (var fc in this.FormContent.FieldChecks.Where(c => c.HtmlVisible && c.Resolved))
            {
                sw.WriteLine("    FldAlert{0}(\"{1}\", false);", fc.CalcId, fc.Data.FID);
            }
            foreach (var fc in this.FormContent.FormChecks.Where(c => c.HtmlVisible && c.Resolved))
            {
                sw.WriteLine("    if(!{0}()) {{", fc.CalcId);
                sw.WriteLine("      showErr(null, '{0}', false);", fc.JSMsg);
                sw.WriteLine("    }");                
            }
            sw.WriteLine("    showErrorDlg();");
            sw.WriteLine("}");

            sw.WriteLine("function attachCalculators() {");

            sw.WriteLine("/* field calculation functions */");
            foreach (var d in this.FormContent.AllDataFields)
            {
                var flds = this.FormContent.FieldCalcs.Where(c => c.HtmlVisible && c.Resolved && c.DependentFields.Contains(d)).ToList();

                if (flds.Count == 0)
                    continue;

                sw.WriteLine("  $('#{0}').change(function() {{", d.FID);
                flds.ForEach(f =>
                {
                    sw.WriteLine("    $('#{0}').val({1}()); ", f.Data.FID, f.CalcId);
                    if(f.Data.Readonly)
                    {
                        sw.WriteLine("    $('#{0}').trigger(\"change\");", f.Data.FID);
                    }
                });
                sw.WriteLine("  });");
            }
            sw.WriteLine("/* field check functions */");
            foreach (var d in this.FormContent.FieldChecks.Where(c => c.HtmlVisible && c.Resolved))
            {
                sw.WriteLine("  $('#{0}').change(function() {{", d.Data.FID);
                sw.WriteLine("    FldAlert{0}(\"{1}\", true);", d.CalcId, d.Data.FID);
                sw.WriteLine("  });");
            }
            sw.WriteLine("/* page check functions */");
            foreach (var p in this.FormContent.PageChecks.Where(c => c.HtmlVisible && c.Resolved))
            {
                foreach (var fld in p.DependentFields)
                {
                    var idx = this.FormContent.Pages.IndexOf(p.Page);
                    sw.WriteLine("  $('#{0}').change(function() {{", fld.FID);
                    sw.WriteLine("    if({0}()) {{", p.CalcId);
                    sw.WriteLine("      $(\"#pages\").tabs('enable', {0});", idx);
                    sw.WriteLine("      pgI[{0}] = true", p.Page.Id);
                    sw.WriteLine("    } else {");
                    sw.WriteLine("      $(\"#pages\").tabs('disable', {0});", idx);
                    sw.WriteLine("      pgI[{0}] = false", p.Page.Id);
                    sw.WriteLine("    }");
                    sw.WriteLine("  });");
                }
            }
            sw.WriteLine("};");

            sw.Close();
        }
    }
}
