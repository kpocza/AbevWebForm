using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebForm.Generator.Model
{
    internal static class FunctionStore
    {
        static FunctionStore()
        {
            fun2fun = new Dictionary<string, string>();
            fun2fun.Add("field", "w_Field");
            fun2fun.Add("getrealzero", "w_GetRealZero");
            fun2fun.Add("round", "w_Round");
            fun2fun.Add("+", "w_opAdd");
            fun2fun.Add("-", "w_opSub");
            fun2fun.Add("*", "w_opMul");
            fun2fun.Add("/", "w_opDiv");
            fun2fun.Add("modulo", "w_opMod");
            fun2fun.Add("=", "w_opIsEq");
            fun2fun.Add("!=", "w_opIsNe");
            fun2fun.Add("<", "w_opIsLt");
            fun2fun.Add(">", "w_opIsGt");
            fun2fun.Add("<=", "w_opIsLe");
            fun2fun.Add(">=", "w_opIsGe");
            fun2fun.Add("&", "w_opAnd");
            fun2fun.Add("|", "w_opOr");
            fun2fun.Add("not", "w_opNot");
            fun2fun.Add("abs", "w_Abs");
            fun2fun.Add("imp", "w_Imp");
            fun2fun.Add("ekv", "w_Ekv");
            fun2fun.Add("substr", "w_SubStr");
            fun2fun.Add("len", "w_Len");
            fun2fun.Add("if", "w_if");
            fun2fun.Add("kitöltött", "w_IsFilled");
            fun2fun.Add("kitöltöttdarab", "w_FilledCount");
            fun2fun.Add("jódátum", "w_IsCorrectDate");//???
            fun2fun.Add("jóadószám", "w_IsCorrectTaxNum");//???
            fun2fun.Add("jóadóazonosító", "w_IsCorrentTaxIdNum");//???
            fun2fun.Add("min", "w_Min");
            fun2fun.Add("max", "w_Max");
            fun2fun.Add("sum", "w_Sum");
            fun2fun.Add("in", "w_In");
            fun2fun.Add("dátumnap", "w_DateDay");
            fun2fun.Add("dátumhó", "w_DateMonth");
            fun2fun.Add("nil", "w_NIL");
        }

        public static string Resolve(string fun)
        {
            if (!fun2fun.ContainsKey(fun.ToLower()))
            {
                Console.WriteLine("Function '{0}' cannot be resolved", fun);
                return UNRESOLVED;
            }
            return fun2fun[fun.ToLower()];
        }

        public static readonly string UNRESOLVED = "FN_UNRESOLVED";
        private static Dictionary<string, string> fun2fun;
    }
}
