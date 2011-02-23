using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace WebForm.Generator.Formulas
{
    public static class FormulaParser
    {
        public static TreeNode DoIt(string formula)
        {
            var lex = new abevformulaLexer(new ANTLRStringStream(formula));
            CommonTokenStream tokens = new CommonTokenStream(lex);

            var parser = new abevformulaParser(tokens);

            var items = new TreeNodes();

            try
            {
                var ret = parser.startIt();
                if (ret.Tree == null)
                {
                    Console.WriteLine("Unable to parse formula (no tree): {0}", formula);
                    return null;
                }
                var ct = (ret.Tree as CommonTree);

                foreach (var c in ct.Children)
                {
                    var tn = new TreeNode(c.ToString());
                    items.Add(tn);
                    BuildTree(tn, c);
                }
            }
            catch (RecognitionException e)
            {
                Console.WriteLine("Unable to parse formula (exception occured): {0}, exception:", formula, e.ToString());
                return null;
            }
            var root = new TreeNode("FUNC");
            root.Children.AddRange(items);
            return root;
        }

        static void BuildTree(TreeNode par, ITree t)
        {
            for (int i = 0; i < t.ChildCount; i++)
            {
                var c = t.GetChild(i);
                var tn = new TreeNode(c.ToString());
                par.Children.Add(tn);
                BuildTree(tn, (CommonTree)c);
            }
        }
    }

    public class TreeNode
    {
        public TreeNode(string val)
        {
            this.Value = val;
            this.Children = new TreeNodes();
        }
        public string Value { get; set; }
        public TreeNodes Children { get; set; }
    }

    public class TreeNodes : List<TreeNode>
    {
    }
}
