using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using WebForm.Generator.Formulas;
using System.IO;

namespace WebForm.Generator.Model
{

    internal class Check : Calc
    {
        public Check(FormContent fc, XmlElement e)
            : base(fc, e)
        {
            this.Msg = IsEmptyAttr("msg");
            this.JSMsg = this.Msg.Replace("\"", "\\\"").Replace("'", "\\'"); // TODO: more replace. Máshol is!
            switch (AsString("msglevel"))
            {
                case "info": this.MsgLevel = MsgLevelEnum.Info; break;
                case "warning": this.MsgLevel = MsgLevelEnum.Warning; break;
                case "error": this.MsgLevel = MsgLevelEnum.Error; break;
                case "fatalerror": this.MsgLevel = MsgLevelEnum.FatalError; break;
            }
            this.ErrorCode = IsEmptyAttr("errorcode");
        }

        public string Msg { get; set; }
        public string JSMsg { get; private set; }
        public MsgLevelEnum MsgLevel { get; set; }
        public string ErrorCode { get; set; }
    }

    internal class PageCheck : Check
    {
        public PageCheck(FormContent fc, XmlElement e)
            : base(fc, e)
        {
            var pid = int.Parse(e.ParentNode.Attributes["pid"].Value);
            this.Page = fc.Pages.SingleOrDefault(p => p.Id == pid);
        }

        public Page Page { get; set; }
    }

    internal class PageChecks : List<PageCheck>
    {
        public PageChecks(FormContent fc, List<XmlElement> lst)
        {
            lst.ForEach(l => this.Add(new PageCheck(fc, l)));
        }
    }

    internal class FormCheck : Check
    {
        public FormCheck(FormContent fc, XmlElement e)
            : base(fc, e)
        {

        }
    }

    internal class FormChecks : List<FormCheck>
    {
        public FormChecks(FormContent fc, List<XmlElement> lst)
        {
            lst.ForEach(l => this.Add(new FormCheck(fc, l)));
        }
    }

    internal class FieldCheck : Check
    {
        public FieldCheck(FormContent fc, XmlElement e)
            : base(fc, e)
        {
            var fid = e.ParentNode.Attributes["fid"].Value;
            this.Data = fc.AllDataFields.SingleOrDefault(f => f.FID == fid);
        }

        public Data Data { get; set; }
    }

    internal class FieldChecks : List<FieldCheck>
    {
        public FieldChecks(FormContent fc, List<XmlElement> lst)
        {
            lst.ForEach(l => this.Add(new FieldCheck(fc, l)));
        }
    }

    internal class FieldCalc : Calc
    {
        public FieldCalc(FormContent fc, XmlElement e)
            : base(fc, e)
        {
            var fid = e.ParentNode.Attributes["fid"].Value;
            this.Data = fc.AllDataFields.SingleOrDefault(f => f.FID == fid);
        }

        public Data Data { get; set; }
    }

    internal class FieldCalcs : List<FieldCalc>
    {
        public FieldCalcs(FormContent fc, List<XmlElement> lst)
        {
            lst.ForEach(l => this.Add(new FieldCalc(fc, l)));
        }
    }
}
