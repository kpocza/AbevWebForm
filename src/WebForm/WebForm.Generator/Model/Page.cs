using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace WebForm.Generator.Model
{
    /// <summary>
    /// Egy lap
    /// </summary>
    internal class Page : XmlProcessable
    {
        /// <summary>
        /// Ehhez a formhoz tartozik
        /// </summary>
        public FormContent ParentForm { get; set; }

        public Page(FormContent parentForm, XmlElement xmlElement)
            : base(xmlElement)
        {
            this.ParentForm = parentForm;

            this.Id = AsInt("pid");
            this.Title = xmlElement.Attributes["title"].Value;
            this.OriginalName = xmlElement.Attributes["name"].Value;
            this.Name = this.OriginalName.ToPLName();
            this.MaxX = AsInt("maxx");
            this.MaxY = AsInt("maxy");
            this.Size = (PageSizeEnum)Enum.Parse(typeof(PageSizeEnum), xmlElement.Attributes["size"].Value);
            this.Orientation = xmlElement.Attributes["orientation"].Value == "portrait" ? PageOrientationEnum.Portrait : PageOrientationEnum.Landscape;

            this.Frames = new Frames(this, xmlElement.SelectNodes("GUIITEM[@type='frame']").Cast<XmlElement>().ToList());
            this.Labels = new Labels(this, xmlElement.SelectNodes("GUIITEM[@type='label']").Cast<XmlElement>().ToList());
            this.AllFields = new Datas(this, xmlElement.SelectNodes("GUIITEM[@type='data']").Cast<XmlElement>().ToList());

            this.AllFields.SortMe();

            this.ParentForm.AllDataFields.AddRange(this.AllFields);

            foreach (var f in this.Frames)
            {
                this.MaxX = Math.Max(this.MaxX, f.X + f.W);
                this.MaxY = Math.Max(this.MaxY, f.Y + f.H);
            }
        }

        internal void StartPage(StreamWriter sw)
        {
            sw.WriteLine("<div style=\"width:{0}px;height:{1}px;position:relative;\" id=\"{2}\">", this.MaxX, this.MaxY, this.UIId);
        }

        internal void EndPage(StreamWriter sw)
        {
            sw.WriteLine("</div>");
        }

        public int Id { get; set; }
        /// <summary>
        /// Címe
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Eredeti neve
        /// </summary>
        public string OriginalName { get; set; }
        /// <summary>
        /// Programozási nyelv kompatibilis név (a nem alfanumerikus karakterekből _ lesz)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Felületi azonosító
        /// </summary>
        public string UIId { get { return "page_" + this.Name; } }

        /// <summary>
        /// Milyen széles
        /// </summary>
        public int MaxX { get; set; }
        /// <summary>
        /// Milyen magas
        /// </summary>
        public int MaxY { get; set; }

        /// <summary>
        /// Keretek
        /// </summary>
        public Frames Frames { get; set; }

        /// <summary>
        /// Címke mezők
        /// </summary>
        public Labels Labels { get; set; }

        /// <summary>
        /// A lap összes adatmezője
        /// </summary>
        public Datas AllFields { get; set; }

        /// <summary>
        /// Méret
        /// </summary>
        public PageSizeEnum Size { get; set; }

        /// <summary>
        /// Állás
        /// </summary>
        public PageOrientationEnum Orientation { get; set; }
    }

    internal class Pages : List<Page>
    {
        public Pages(FormContent form, List<XmlElement> pgs)
        {
            pgs.ForEach(p => this.Add(new Page(form, p)));
        }
    }
}
