using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WebForm.Generator.Model
{
    internal abstract class XmlProcessable
    {
        public XmlElement E { get; set; }

        public XmlProcessable(XmlElement e)
        {
            this.E = e;
        }

        protected bool IsExists(string name)
        {
            return E.Attributes[name] != null;
        }

        protected string IsNullAttr(string name)
        {
            if (E.Attributes[name] != null)
            {
                return E.Attributes[name].Value;
            }
            return null;
        }

        protected string IsEmptyAttr(string name)
        {
            return IsNullAttr(name) ?? string.Empty;
        }

        protected int AsInt(string name)
        {
            return int.Parse(E.Attributes[name].Value);
        }

        protected string AsString(string name)
        {
            return E.Attributes[name].Value;
        }
    }
}
