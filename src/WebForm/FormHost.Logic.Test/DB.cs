using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormHost.Logic.Test
{
    [TestClass]
    public class DB
    {
        [TestMethod]
        public void ScriptTest()
        {
            var creScript = UnitTestHelper.GetDBScript();

           //var ts = new TemplateService(null);
            //ts.ListLastDocVersionsOfOrganization(new Model.Forms.Organization { Id = 1 });
        }
    }
}
