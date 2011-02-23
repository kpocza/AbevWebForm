using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;

namespace WebForm.Generator.Model
{
    internal abstract class ElementBase : XmlProcessable
    {
        public ElementBase(Page p, XmlElement e)
            : base(e)
        {
            this.Page = p;
            this.X = AsInt("x");
            this.Y = AsInt("y");
            this.W = AsInt("w");
            this.H = AsInt("h");

            this.BGColor = e.Attributes["bgcolor"].Value;
            this.FGColor = e.Attributes["fgcolor"].Value;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }

        public string BGColor { get; set; }
        public string FGColor { get; set; }

        public Page Page { get; set; }
    }

    internal class Elements : List<ElementBase>
    {
    }

    internal abstract class FieldBase : ElementBase
    {
        protected internal static List<string> FieldCssClass { get; set; }

        public FieldBase(Page page, XmlElement e)
            : base(page, e)
        {
            this.FontName = e.Attributes["fontname"].Value;
            this.FontType = FontTypeEnum.Normal;
            switch (e.Attributes["fonttype"].Value)
            {
                case "bold": this.FontType = FontTypeEnum.Normal; break;
                case "italic": this.FontType = FontTypeEnum.Italic; break;
                case "bolditalic": this.FontType = FontTypeEnum.BoldItalic; break;
            }
            this.FontSize = int.Parse(e.Attributes["fontsize"].Value);

            this.TextAlignment = AlignmentEnum.Left;
            switch (e.Attributes["alignment"].Value)
            {
                case "center": this.TextAlignment = AlignmentEnum.Center; break;
                case "right": this.TextAlignment = AlignmentEnum.Right; break;
            }
            // TODO: textcolor

            this.Printable = true;
            if (IsEmptyAttr("printable").ToLower() == "false")
            {
                this.Printable = false;
            }
        }

        static FieldBase()
        {
            Init();
        }

        internal static void Init()
        {
            FieldCssClass = new List<string>();
        }

        protected string GetCustomStyle(bool isReadonly = false)
        {
            int x = this.X;
            int y = this.Y;

            int w = this.W;
            int h = this.H;

            return string.Format("left:{0}px;top:{1}px;width:{2}px;height:{3}px;{4}", x, y, w, h, isReadonly ? "border:#ccc 1px solid;" : string.Empty);
        }

        protected string GetCommonClass(bool isReadonly = false)
        {
            var bgColor = string.Empty;
            if (isReadonly)
            {
                bgColor = "background-color:#ffd5d5;";
            }

            var border = "border-width:0px";

            if (this is Data)
            {
                var d = this as Data;
                if (d.BorderSide.HasValue && d.BorderWidth > 0)
                {
                    var bw = d.BorderWidth.ToString() + "px;";
                    border = "border-color:#" + d.FGColor + ";";
                    if ((d.BorderSide & BorderSideEnum.Left) == BorderSideEnum.Left)
                    {
                        border += "border-left-width:" + bw;
                    }
                    else
                    {
                        border += "border-left-width:0px;";
                    }
                    if ((d.BorderSide & BorderSideEnum.Right) == BorderSideEnum.Right)
                    {
                        border += "border-right-width:" + bw;
                    }
                    else
                    {
                        border += "border-right-width:0px;";
                    }
                    if ((d.BorderSide & BorderSideEnum.Bottom) == BorderSideEnum.Bottom)
                    {
                        border += "border-bottom-width:" + bw;
                    }
                    else
                    {
                        border += "border-bottom-width:0px;";
                    }
                    if ((d.BorderSide & BorderSideEnum.Top) == BorderSideEnum.Top)
                    {
                        border += "border-top-width:" + bw;
                    }
                    else
                    {
                        border += "border-top-width:0px;";
                    }
                }
            }

            var lblRot = string.Empty;
            //if (this is Label)
            //{
            //    var lbl = this as Label;
            //    if (lbl.Rotation == LabelRotationEnum.Angle90)
            //    {
            //        lblRot = "-webkit-transform: rotate(90deg); -moz-transform: rotate(90deg);filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=1);";
            //    }
            //    else if (lbl.Rotation == LabelRotationEnum.Angle270)
            //    {
            //        lblRot = "-webkit-transform: rotate(-90deg); -moz-transform: rotate(-90deg);filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);";
            //    }
            //}

            var stamp = string.Format("position:absolute;padding:0px;font-size:{0}px;{1}{2}{3}{4}{5}{6}", this.FontSize, Alignment2CSS(this.TextAlignment), FontType2CSS(this.FontType), FontName2Css(this.FontName), bgColor, border, lblRot);

            if (!FieldCssClass.Contains(stamp))
            {
                FieldCssClass.Add(stamp);
            }

            return "fldc" + FieldCssClass.IndexOf(stamp);
        }

        protected string FontType2CSS(FontTypeEnum fontType)
        {
            switch (fontType)
            {
                case FontTypeEnum.Normal: return "font-style:normal;";
                case FontTypeEnum.Bold: return "font-weight:bold;";
                case FontTypeEnum.Italic: return "font-style:italic;";
                case FontTypeEnum.BoldItalic: return "font-style:italic;font-weight:bold;";
            }
            return string.Empty;
        }

        protected string FontName2Css(string fontName)
        {
            if (fontName.Contains(' '))
            {
                return "font-family:\"" + fontName + "\";";
            }

            return "font-family:" + fontName + ";";
        }

        protected string Alignment2CSS(AlignmentEnum alignment)
        {
            switch (alignment)
            {
                case AlignmentEnum.Left: return "text-align:left;";
                case AlignmentEnum.Right: return "text-align:right;";
                case AlignmentEnum.Center: return "text-align:center;";
            }
            return string.Empty;
        }

        protected internal static string Abev2HtmlString(string str)
        {
            return HttpUtility.HtmlEncode(str.Replace("#", "<br/>")).Replace("&lt;br/&gt;", "<br/>");
        }

        public string FontName { get; set; }
        public FontTypeEnum FontType { get; set; }
        public int FontSize { get; set; }
        public AlignmentEnum TextAlignment { get; set; }

        public string TextColor { get; set; }

        public bool Printable { get; set; }
    }

    internal class Fields : List<FieldBase>
    {
    }
}
