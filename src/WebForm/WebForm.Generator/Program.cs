using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebForm.Generator.Html;
using WebForm.Generator.Common;
using System.IO;
using WebForm.Generator.Formulas;

namespace WebForm.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            if (args[0] == "/html" && args.Length == 3)
            {
                var contentBuilder = new ContentBuilder(args[1]);
                var formContent = contentBuilder.Build();
                var htmlGen = new HtmlGenerator(formContent, GetFullOutDir(args[2]));
                htmlGen.Do();
                var calcGen = new CalcGenerator(formContent, GetFullOutDir(args[2]));
                calcGen.Do();
                return;
            }
            ShowHelp();
        }

        private static string GetFullOutDir(string pathPart)
        {
            if (Path.IsPathRooted(pathPart))
            {
                return pathPart;
            }

            return Path.Combine(Directory.GetCurrentDirectory(), pathPart);
        }

        private static void ShowHelp()
        {
            Console.WriteLine("/html inputfile.jar outdir");
        }
    }
}
