﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Common;
using FormHost.DataAccess;
using FormHost.DataAccess.Base;
using FormHost.Model.Forms;

namespace FormHost.DataAccess
{
    public class OrganizationRepository : RepositoryBase<Organization, Organizations, DataContext>
    {
        public OrganizationRepository(DataContext dc) : base(dc) { }
    }
}