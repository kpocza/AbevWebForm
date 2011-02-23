using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using WebForm.Generator.Model;

namespace WebForm.Generator.Common
{
    internal class ContentBuilder
    {
        private string InputFile { get; set; }

        internal ContentBuilder(string inputFile)
        {
            InputFile = inputFile;
        }

        internal FormContent Build()
        {
            var zipHandler = new ZipHandler(this.InputFile);
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(new MemoryStream(zipHandler.GetENYK()));

            var forms = xmlDocument.DocumentElement.SelectNodes("/FILE/FORMS/FORM");

            if (forms.Count != 1)
            {
                throw new Exception("Nem pontosan egy formot tartalmaz az ENYK");
            }
            return new FormContent((XmlElement)forms[0]);
        }
    }
}
