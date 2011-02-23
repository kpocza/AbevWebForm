using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WebForm.Generator.Model
{
    internal class InputRule : XmlProcessable
    {
        public InputRule(FormContent formContent, XmlElement e)
            : base(e)
        {
            this.Irid = AsInt("irid");
            this.Rule = AsString("irule");
            this.FormContent = formContent;

            string jsRule = null;
            switch(this.Rule)
            {
                case "[A-Z]": jsRule = "/[a-zA-Z]/"; break;
                case "[0-9,.]": jsRule = "/[0-9,.]/"; break;
                case "[0-9]": jsRule = "/[0-9]/"; break;
                case @"[0-9+\-,.]": jsRule = @"/[0-9+\-,.]/"; break;
                case "[A-Z0-9]": jsRule = "/[a-zA-Z0-9]/i"; break;
                case @"[A-ZÁÉÍÓÖŐÚÜŰ]": jsRule = "/[a-zA-ZáéíóöőúüűÁÉÍÓÖŐÚÜŰ]/i"; break;
                case @"[^0-9]": jsRule = "/[^0-9]/"; break;
                //case @"[\x20-\uFFFF]": jsRule = @"/[\0x20-\uffff]/i"; break;
                //case @"[ X]": jsRule = "checkbox!!!"; break;
                case @"[0-9+-]": jsRule = @"/[0-9+\-]/"; break;
            }

            JSRule = jsRule;
        }

        public int Irid { get; set; }
        public string Rule { get; set; }
        public FormContent FormContent { get; set; }
        public string JSRule { get; set; }
        public bool IsValid { get { return JSRule!= null;} }
    }

    internal class InputRules : List<InputRule>
    {
        public InputRules(FormContent form, List<XmlElement> irs)
        {
            irs.ForEach(p => this.Add(new InputRule(form, p)));
        }
    }

    internal interface IMaskable
    {
        string Mask { get; set; }
        string JSMask { get; set; }
    }

    internal static class MaskHelper
    {
        public static void CalcJSMask(IMaskable d)
        {
            if (string.IsNullOrWhiteSpace(d.Mask))
            {
                d.JSMask = null;
                return;
            }

            string maskPart = d.Mask.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries)[0];

            if (maskPart.Contains("%"))
            {
                d.JSMask = null;
                return;
            }

            if (d is DataDate)
            {
                d.JSMask = maskPart.Replace('#', '9');
                return;
            }

            d.JSMask = maskPart.Replace('#', '*');
        }
    }

}
