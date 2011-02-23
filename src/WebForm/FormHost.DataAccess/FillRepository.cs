using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Common;
using FormHost.DataAccess;
using FormHost.DataAccess.Base;
using FormHost.Model.Fillings;

namespace FormHost.DataAccess
{
    public class FillRepository : RepositoryBase<Fill, Fills, DataContext>
    {
        public FillRepository(DataContext dc) : base(dc) { }
    }
}
