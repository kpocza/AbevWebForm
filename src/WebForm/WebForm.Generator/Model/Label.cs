using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace WebForm.Generator.Model
{
    internal class Label : FieldBase
    {
        public Label(Page page, XmlElement xml)
            : base(page, xml)
        {
            // hogy jól nézzen ki
            this.W += 4;

            this.Text = xml.Attributes["value"].Value;
            
            this.Rotation = LabelRotationEnum.None;
            if (this.IsExists("rotation"))
            {
                int rotAng = this.AsInt("rotation");
                if (rotAng == 1)
                {
                    this.Rotation = LabelRotationEnum.Angle90;
                }
                else if (rotAng == 3)
                {
                    this.Rotation = LabelRotationEnum.Angle270;
                }
            }
        }

        internal void WriteLabel(StreamWriter sw)
        {
            sw.WriteLine("    <div style=\"{0}\" class=\"{1}\">{2}</div>", GetCustomStyle(), GetCommonClass(), Abev2HtmlString(Text));
        }

        public string Text { get; set; }
        public LabelRotationEnum Rotation { get; set; }
    }

    internal class Labels : List<Label>
    {
        public Labels(Page page, List<XmlElement> list)
        {
            list.ForEach(l => this.Add(new Label(page, l)));
        }
    }
}
