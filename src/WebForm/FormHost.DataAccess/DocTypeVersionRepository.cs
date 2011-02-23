using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Common;
using FormHost.DataAccess;
using FormHost.DataAccess.Base;
using FormHost.Model.Forms;

namespace FormHost.DataAccess
{
    public class DocTypeVersionRepository : RepositoryBase<DocTypeVersion, DocTypeVersions, DataContext>
    {
        public DocTypeVersionRepository(DataContext dc) : base(dc) { }
    }
}
