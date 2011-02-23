using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.DataAccess;

namespace FormHost.Logic
{
    public static class UnitTestHelper
    {
        public static string GetDBScript()
        {
            return new DataContext().BuildScript();
        }
    }
}
