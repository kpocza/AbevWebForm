using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using WebForm.Generator.Formulas;
using System.IO;

namespace WebForm.Generator.Model
{
    internal class Var : CalcBase
    {
        public Var(FormContent fc, XmlElement e)
            : base(fc, e)
        {
            this.Name = AsString("name");
            this.OriginalName = this.Name;
            if (this.Name.Length > 0 && char.IsDigit(this.Name[0]))
            {
                this.Name = "var_" + this.Name;
            }
            this.Expression = AsString("value");
            this.Role = AsInt("role");
            this.ExpTree = FormulaParser.DoIt(this.Expression);
            this.depends = new HashSet<string>();
            this.Resolved = true;
            this.DependentFields = new Datas();
            this.DependentFields.AddRange(depends.ToList().ConvertAll(v => fc.AllDataFields[v.Trim(new char[] { '"' })]));
        }

        public string Name { get; set; }
        public string OriginalName { get; set; }

        public override void WriteFunc(StreamWriter sw)
        {
            sw.WriteLine("function {0}() {{", Name);
            sw.WriteLine("  return " + JSCalc + ";");
            sw.WriteLine("}");
        }

        public void CalcJS()
        {
            this.JSCalc = ToJSCalcInner(ExpTree);
        }
    }

    internal class Vars : List<Var>
    {
        public Vars(FormContent fc, List<XmlElement> lst)
        {
            lst.ForEach(l => this.Add(new Var(fc, l)));
        }

        public bool Contains(string name)
        {
            return this.Exists(v => v.Name == name);
        }

        public bool ContainsByOriginalName(string name)
        {
            return this.Exists(v => v.OriginalName == name);
        }

        public Var ByOriginalName(string originalName)
        {
            return this.SingleOrDefault(v => v.OriginalName == originalName);
        }

        public void CalcJS()
        {
            this.ForEach(v => v.CalcJS());
        }
    }
}
