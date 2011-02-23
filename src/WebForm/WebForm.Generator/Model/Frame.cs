using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace WebForm.Generator.Model
{
    internal class Frame : ElementBase
    {
        public Frame(Page page, XmlElement a)
            : base(page, a)
        {
            this.LineWidth = 1;
            if (IsExists("linewidth"))
            {
                this.LineWidth = AsInt("linewidth");
            }

            if (IsExists("rx"))
            {
                RX = AsInt("rx");
            }
            if (IsExists("ry"))
            {
                RY = AsInt("ry");
            }
        }

        internal void WriteFrame(StreamWriter sw )
        {
            var border = string.Empty;

            if (this.W > 1 && this.H > 1)
            {
                border = string.Format("border: {0}px #{1} solid;", this.LineWidth, this.FGColor);
            }

            if (this.W <= 1 && this.H > 1)
            {
                border = string.Format("border-left: {0}px #{1} solid;", this.LineWidth, this.FGColor);
            }
            if (this.W > 1 && this.H <= 1)
            {
                border = string.Format("border-top: {0}px #{1} solid;", this.LineWidth, this.FGColor);
            }

            int w = this.W;
            int h = this.H;
            if (w == 1) w = 0;
            if (h == 1) h = 0;

            var radius = string.Empty;

            var rx = this.RX;
            var ry = this.RY;

            if(rx.HasValue && !ry.HasValue)
            {
                ry = rx;
            }
            else if(ry.HasValue && !rx.HasValue)
            {
                rx = ry;
            }

            if (rx.HasValue && ry.HasValue)
            {
                radius = string.Format("border-radius: {0}px / {1}px;", rx, ry);
            }

            sw.WriteLine("  <div style=\"position:absolute;left:{0}px;top:{1}px;width:{2}px;height:{3}px;background-color:#{4};{5}line-height:0px;font-size:0px;{6}\"></div>",
                this.X, this.Y, w, h, this.BGColor, border, radius);
        }


        public int LineWidth { get; set; }
        public bool Top { get; set; }

        public int? RX { get; set; }
        public int? RY { get; set; }
    }

    internal class Frames : List<Frame>
    {
        public Frames(Page page, List<XmlElement> xmlNodeList)
        {
            xmlNodeList.ForEach(a => this.Add(new Frame(page, a)));
        }
    }
}
