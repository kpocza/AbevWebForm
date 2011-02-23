using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using WebForm.Generator.Formulas;
using System.IO;

namespace WebForm.Generator.Model
{
    internal abstract class CalcBase : XmlProcessable
    {
        public CalcBase(FormContent fc, XmlElement e)
            : base(e)
        {
            this.FormContent = fc;
        }

        public string Expression { get; set; }
        public TreeNode ExpTree { get; set; }
        public FormContent FormContent { get; set; }
        protected HashSet<string> depends;
        public Datas DependentFields { get; set; }
        public string JSCalc { get; protected set; }
        public int Role { get; set; }
        public bool HtmlVisible { get { return (this.Role & 1) == 1; } }
        public bool Resolved { get; set; }

        protected internal string ToJSCalcInner(TreeNode par)
        {
            var funcName = par.Children[0].Value;
            if (funcName == "field" && par.Children.Count == 2)
            {
                this.depends.Add(par.Children[1].Value);
            }
            funcName = FunctionStore.Resolve(funcName);

            if (funcName == FunctionStore.UNRESOLVED)
            {
                Resolved = false;
            }

            var maybevar = FormContent.Vars.ByOriginalName(funcName);
            if (maybevar != null)
            {
                funcName = maybevar.Name;
            }

            var res = funcName + "(";
            for (int i = 1; i < par.Children.Count; i++)
            {
                var tn = par.Children[i];
                if (tn.Value == "FUNC")
                {
                    res += ToJSCalcInner(tn);
                }
                else
                {
                    if (tn.Value.ToLower() == "nil")
                    {
                        res += "w_NIL()";
                    }
                    else
                    {
                        if (this.FormContent.Vars == null || !this.FormContent.Vars.ContainsByOriginalName(tn.Value))
                        {
                            res += tn.Value;
                        }
                        else if (this.FormContent.Vars != null && this.FormContent.Vars.ContainsByOriginalName(tn.Value))
                        {
                            var variable = this.FormContent.Vars.ByOriginalName(tn.Value);
                            if (variable == null)
                            {
                                res += tn.Value;
                            }
                            else
                            {
                                res += variable.Name + "()";
                            }
                        }
                        //res += tn.Value;
                        //if (this.FormContent.Vars != null && this.FormContent.Vars.Contains(tn.Value))
                        //{
                        //    res += "()";
                        //}
                    }
                }
                if (i < par.Children.Count - 1)
                {
                    res += ",";
                }
            }
            res += ")";
            return res;
        }

        public abstract void WriteFunc(StreamWriter sw);
    }

    internal class Calc : CalcBase
    {
        public Calc(FormContent fc, XmlElement e)
            : base(fc, e)
        {
            this.CalcId = CIDGen.Next();
            this.Expression = AsString("cexp");
            this.OnEvent = AsString("on_event");
            this.Role = AsInt("role");
            this.ExpTree = FormulaParser.DoIt(this.Expression);
            this.depends = new HashSet<string>();
            this.Resolved = true;
            this.JSCalc = ToJSCalcInner(ExpTree);
            this.DependentFields = new Datas();
            this.DependentFields.AddRange(depends.ToList().ConvertAll(v => fc.AllDataFields[v.Trim(new char[] { '"' })]));
        }

        public string CalcId { get; set; }
        public string OnEvent { get; set; }

        public override void WriteFunc(StreamWriter sw)
        {
            sw.WriteLine("function {0}() {{", CalcId);
            sw.WriteLine("  return " + JSCalc + ";");
            sw.WriteLine("}");
        }
    }

    internal static class CIDGen
    {
        private static int _val;

        static CIDGen()
        {
            _val = 0;
        }
        public static string Next()
        {
            _val++;
            return "CID" + _val;
        }
    }
}
