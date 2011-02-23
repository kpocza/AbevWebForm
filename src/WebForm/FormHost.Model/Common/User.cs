using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Base;

namespace FormHost.Model.Common
{
    public class User : IDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Users : DomainEntityContainer<User>
    {
    }
}
