using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WebForm.Generator.Model
{
    internal class Meta : XmlProcessable
    {
        public FormContent FormContent { get; set; }

        internal Meta(FormContent formContent, XmlElement xe) : base(xe)
        {
            this.FormContent = formContent;

            this.Data = formContent.AllDataFields[xe.Attributes["fid"].Value];
            this.Data.Meta = this;
            this.Name = xe.Attributes["vid"].Value;
            this.Irids = IsEmptyAttr("irids").Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(ir => int.Parse(ir));

            // TODO: multiple input rules not supported
            if (this.Irids.Count > 1)
            {
                this.Irids.Clear();
            }

            this.FieldType = (MetaFieldType)AsInt("type");
            this.DefaultValue = IsNullAttr("defaultvalue");
            this.CopySource = IsNullAttr("copy_fld");
            this.EvelopeField = IsNullAttr("envelope");
            this.Row = AsInt("row");
            this.Col = AsInt("col");

            if (this.FieldType == MetaFieldType.Number && this.Data.FieldTypeBase == FieldTypeBaseEnum.Text)
            {
                this.Data.FieldTypeBase = FieldTypeBaseEnum.Number;
            }
        }

        public Data Data { get; set; }
        public string Name { get; set; }
        public List<int> Irids { get; set; }
        public MetaFieldType FieldType { get; set; }

        public string DefaultValue { get; set; }

        public string CopySource { get; set; }
        public string EvelopeField { get; set; }

        public int Row { get; set; }
        public int Col { get; set; }
    }

    internal class Metas : List<Meta>
    {
        public Metas() { }

        public Metas(FormContent formContent, List<XmlElement> list)
        {
            // TODO: VPOP_kt11bev_20110712.jar miatti elszámmlás hackolását normálisan megoldani 
            list.ForEach(l => { try { this.Add(new Meta(formContent, l)); } catch { } });
        }
    }
}
