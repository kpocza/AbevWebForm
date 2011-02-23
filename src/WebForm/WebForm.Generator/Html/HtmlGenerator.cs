using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebForm.Generator.Model;
using System.IO;

namespace WebForm.Generator.Html
{
    internal class HtmlGenerator : BaseGenerator
    {
        internal HtmlGenerator(FormContent formContent, string outDir)
            : base(formContent, outDir)
        {
            FieldBase.Init();
        }

        internal void Do()
        {
            Directory.CreateDirectory(OutputDirectory);

            var sw = new StreamWriter(Path.Combine(OutputDirectory, "form.html"), false, Encoding.UTF8);

            this.FormContent.BeginOutput(sw);

            foreach (var p in FormContent.Pages)
            {
                p.StartPage(sw);

                foreach (var f in p.Frames)
                {
                    f.WriteFrame(sw);
                }

                foreach (var l in p.Labels)
                {
                    l.WriteLabel(sw);
                }

                foreach (var d in p.AllFields)
                {
                    d.WriteDataField(sw);
                }

                p.EndPage(sw);
            }

            this.FormContent.EndOutput(sw);
            sw.Close();

            sw = new StreamWriter(Path.Combine(OutputDirectory, "form.css"), false, Encoding.UTF8);
            WriteFormCSS(sw);
            sw.Close();
        }

        private void WriteFormCSS(StreamWriter sw)
        {
            for (int i = 0; i < FieldBase.FieldCssClass.Count; i++)
            {
                sw.WriteLine(".fldc" + i.ToString() + "{" + FieldBase.FieldCssClass[i] + "}");
            }
        }
    }
}
