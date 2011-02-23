using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace WebForm.Generator.Model
{
    internal class DataText : Data, IMaskable
    {
        public DataText(Page p, XmlElement e)
            : base(p, e)
        {
            ControlType = ControlTypeEnum.Text;
            FieldTypeBase = FieldTypeBaseEnum.Text;

            this.Mask = IsNullAttr("mask");
            MaskHelper.CalcJSMask(this);
            if (this.BorderSide.HasValue)
            {
                this.BorderSide = BorderSideEnum.Bottom;
            }
        }

        protected override void Write(StreamWriter sw)
        {
            sw.WriteLine(" <input id=\"{0}\" name=\"{0}\" type=\"text\" style=\"{1}\" class=\"{2}\"/>", this.FID, GetCustomStyle(), GetCommonClass());
        }

        public string JSMask { get; set; }
        public string Mask { get; set; }
    }

    internal class DataCheck : Data
    {
        public DataCheck(Page p, XmlElement e)
            : base(p, e)
        {
            ControlType = ControlTypeEnum.Check;
            FieldTypeBase = FieldTypeBaseEnum.Bool;

            if (this.BorderSide.HasValue)
            {
                this.BorderSide = BorderSideEnum.Bottom;
            }
        }

        protected override void Write(StreamWriter sw)
        {
            sw.WriteLine(" <input id=\"{0}\" name=\"{0}\" type=\"checkbox\" style=\"{1}\" class=\"{2}\"/>", this.FID, GetCustomStyle(), GetCommonClass());
        }
    }

    internal class DataCombo : Data
    {
        public DataCombo(Page p, XmlElement e)
            : base(p, e)
        {
            ControlType = ControlTypeEnum.Combo;
            FieldTypeBase = FieldTypeBaseEnum.Text;

            string values = IsEmptyAttr("values");
            string list = IsEmptyAttr("list");

            Items = new List<Tuple<string, string>>();

            var valItems = SplitItems(values);
            var lstItems = SplitItems(list);

            if (lstItems.Length == valItems.Length)
            {
                for (int i = 0; i < valItems.Length; i++)
                {
                    Items.Add(new Tuple<string, string>(valItems[i], lstItems[i]));
                }
            }
            else
            {
                for (int i = 0; i < valItems.Length; i++)
                {
                    Items.Add(new Tuple<string, string>(valItems[i], valItems[i]));
                }
            }

            if (this.BorderSide.HasValue)
            {
                this.BorderSide = BorderSideEnum.Bottom;
            }
        }

        protected override void Write(StreamWriter sw)
        {
            sw.WriteLine(" <select id=\"{0}\" name=\"{0}\" style=\"{1}\" class=\"{2}\" >", this.FID, GetCustomStyle(), GetCommonClass());
            sw.WriteLine("  <option value=\"\"></option>");
            foreach (var opt in this.Items)
            {
                sw.WriteLine("  <option value=\"{0}\">{1}</option>", opt.Item1, Abev2HtmlString(opt.Item2));
            }
            sw.WriteLine(" </select>");
        }

        public List<Tuple<string, string>> Items { get; set; }

        private string[] SplitItems(string val)
        {
            var items = val.Replace("/,", "#comma#").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = items[i].Replace("#comma#", ",");
            }
            return items;
        }
    }

    internal class DataDate : Data, IMaskable
    {
        public DataDate(Page p, XmlElement e)
            : base(p, e)
        {
            ControlType = ControlTypeEnum.Date;
            FieldTypeBase = FieldTypeBaseEnum.Date;

            if (this.BorderSide.HasValue)
            {
                this.BorderSide = BorderSideEnum.Bottom;
            }
            this.Mask = "####-##-##";

            MaskHelper.CalcJSMask(this);
        }

        protected override void Write(StreamWriter sw)
        {
            sw.WriteLine(" <input id=\"{0}\" name=\"{0}\" type=\"text\" style=\"{1}\" class=\"{2}\"/>", this.FID, GetCustomStyle(), GetCommonClass());
        }

        public string JSMask { get; set; }
        public string Mask { get; set; }
    }

    internal class DataTText : Data, IMaskable
    {
        public DataTText(Page p, XmlElement e)
            : base(p, e)
        {
            ControlType = ControlTypeEnum.TText;
            FieldTypeBase = FieldTypeBaseEnum.Text;

            this.Mask = IsNullAttr("mask");
            MaskHelper.CalcJSMask(this);
            if (this.BorderSide.HasValue)
            {
                this.BorderSide = BorderSideEnum.Bottom;
            }
        }

        protected override void Write(StreamWriter sw)
        {
            sw.WriteLine(" <input id=\"{0}\" name=\"{0}\" type=\"text\" style=\"{1}\" class=\"{2}\"/>", this.FID, GetCustomStyle(), GetCommonClass());
        }

        public string JSMask { get; set; }
        public string Mask { get; set; }
    }

    internal class DataFText : Data, IMaskable
    {
        public DataFText(Page p, XmlElement e)
            : base(p, e)
        {
            ControlType = ControlTypeEnum.FText;
            FieldTypeBase = FieldTypeBaseEnum.Text;
            this.Mask = IsNullAttr("mask");
            MaskHelper.CalcJSMask(this);
        }

        protected override void Write(StreamWriter sw)
        {
            sw.WriteLine(" <input id=\"{0}\" name=\"{0}\" type=\"text\" style=\"{1}\" class=\"{2}\"/>", this.FID, GetCustomStyle(), GetCommonClass());
        }

        public string JSMask { get; set; }
        public string Mask { get; set; }
    }

    internal class DataScrollTAText : Data, IMaskable
    {
        public DataScrollTAText(Page p, XmlElement e)
            : base(p, e)
        {
            ControlType = ControlTypeEnum.ScroolTAText;
            FieldTypeBase = FieldTypeBaseEnum.Text;
            this.Mask = IsNullAttr("mask");
            MaskHelper.CalcJSMask(this);
            this.Editable = IsEmptyAttr("editable").ToLower() == "true";
        }

        protected override void Write(StreamWriter sw)
        {
            sw.WriteLine("scrlttext");
        }

        public string Mask { get; set; }
        public string JSMask { get; set; }
        public bool Editable { get; set; }
    }
}
