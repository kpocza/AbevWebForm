using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Common;
using FormHost.DataAccess;
using FormHost.DataAccess.Base;

namespace FormHost.DataAccess
{
    public class UserRepository : RepositoryBase<User, Users, DataContext>
    {
        public UserRepository(DataContext dc) : base(dc) { }
    }
}
