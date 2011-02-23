using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;

namespace WebForm.Generator.Model
{
    internal class Data : FieldBase
    {
        public Data(Page p, XmlElement e)
            : base(p, e)
        {
            this.FID = e.Attributes["fid"].Value;
            this.ToolTip = IsEmptyAttr("tool_tip");
            this.Visible = !(IsEmptyAttr("visible").ToLower() == "no");
            this.Readonly = IsExists("readonly");
            this.Writeable = IsExists("writeable");
            this.Role = AsInt("role");

            if (IsExists("frame_sides"))
            {
                this.BorderSide = (BorderSideEnum)AsInt("frame_sides");
                this.BorderWidth = AsInt("frame_line_width");
            }
            ControlType = ControlTypeEnum.Undef;
            FieldTypeBase = FieldTypeBaseEnum.Undef;
        }

        internal void WriteDataField(StreamWriter sw)
        {
            if (this.HtmlVisible)
            {
                if (!this.Readonly)
                {
                    Write(sw);
                }
                else
                {
                    sw.WriteLine(" <input id=\"{0}\" name=\"{0}\" type=\"text\" readonly=\"readonly\" style=\"{1}\" class=\"{2}\" />", this.FID, GetCustomStyle(true), GetCommonClass(true));
                }
            }
        }

        protected virtual void Write(StreamWriter sw)
        {
            sw.WriteLine("TODO");
        }

        public string FID { get; set; }
        public string ToolTip { get; set; }
        public bool Visible { get; set; }
        public bool Readonly { get; set; }
        public bool Writeable { get; set; }
        public int Role { get; set; }

        public BorderSideEnum? BorderSide { get; set; }
        public int BorderWidth { get; set; }

        public bool HtmlVisible { get { return this.Visible && (this.Role & 1) == 1; } }

        public Meta Meta { get; set; }

        public ControlTypeEnum ControlType { get; protected set; }
        public FieldTypeBaseEnum FieldTypeBase { get; protected internal set; }
    }

    internal class Datas : List<Data>
    {
        public Datas() { }

        public Datas(Page page, List<XmlElement> list)
        {
            foreach (var l in list)
            {
                Data toAdd = null;
                switch (l.Attributes["datatype"].Value)
                {
                    case "text": toAdd = new DataText(page, l); break;
                    case "check": toAdd = new DataCheck(page, l); break;
                    case "combo": toAdd = new DataCombo(page, l); break;
                    case "tcombo": toAdd = new DataCombo(page, l); break; //????
                    case "date": toAdd = new DataDate(page, l); break;
                    case "ttext": toAdd = new DataTText(page, l); break;
                    case "ftext": toAdd = new DataFText(page, l); break;
                    case "scrolltatext ": toAdd = new DataScrollTAText(page, l); break;
                }

                if (toAdd != null)
                {
                    if (toAdd is DataCombo && (toAdd as DataCombo).Items.Count == 0)
                    {
                        toAdd = new DataFText(page, l);
                    }

                    this.Add(toAdd);
                }
            }
        }


        public void SortMe()
        {
            this.Sort((a, b) =>
            {
                int rp = RowPos(a.Y, a.Y + a.H, b.Y, b.Y + b.H);

                if (rp != 0)
                    return rp;

                return a.X.CompareTo(b.X);
            });
        }

        public int RowPos(int y1a, int y2a, int y1b, int y2b)
        {
            if (y2b <= y1a && y1b >= y2a)
                return 0;
            return y1a.CompareTo(y1b);
        }

        public Data this[string fid]
        {
            get
            {
                try
                {
                    return this.Single(f => f.FID == fid);
                }
                catch
                {
                    Console.WriteLine(fid);
                    throw;
                }
            }
        }
    }
}
