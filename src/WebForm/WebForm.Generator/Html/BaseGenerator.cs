using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebForm.Generator.Model;
using System.IO;

namespace WebForm.Generator.Html
{
    abstract class BaseGenerator
    {
        protected string OutputDirectory { get; set; }
        protected FormContent FormContent { get; set; }

        internal BaseGenerator(FormContent formContent, string outDir)
        {
            Directory.CreateDirectory(outDir);
            this.FormContent = formContent;
            this.OutputDirectory = FullOutDir(formContent, outDir);
        }

        protected static string FullOutDir(FormContent fc, string baseOutDir)
        {
            return Path.Combine(Path.Combine(Path.Combine(baseOutDir, fc.Organization), fc.DocType), fc.Version);
        }
    }
}
