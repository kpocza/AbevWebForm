using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WebForm.Generator.Model
{
    /// <summary>
    /// Csatolmány
    /// </summary>
    internal class Attachment : XmlProcessable
    {
        public Attachment(XmlElement a) : base(a)
        {
            // azonosító
            Id = AsInt("id");
            // leírás
            Description = a.Attributes["description"].Value;
            // kötelező
            Required = a.Attributes["required"].Value == "1";
            // min db
            MinCount = AsInt("min_count");
            // max db
            MaxCount = AsInt("max_count");
            // elfogadható kiterjesztések
            Extensions = new List<string>(a.Attributes["file_extensions"].Value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Azonosító
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Leírás
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Kötelező-e
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// Min ennyi db
        /// </summary>
        public int MinCount { get; set; }
        /// <summary>
        /// Max ennyi db
        /// </summary>
        public int MaxCount { get; set; }
        /// <summary>
        /// Elfogadható kiterjeszések PDF, DOC, DOSSZIE, ES3, stb.
        /// </summary>
        public List<string> Extensions { get; set; }
    }

    internal class Attachments : List<Attachment>
    {
        public Attachments(List<XmlElement> atts)
        {
            atts.ForEach(a => this.Add(new Attachment(a)));
        }
    }
}
