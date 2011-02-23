using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Base;

namespace FormHost.Model.Forms
{
    public class Organization : IDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }

    public class Organizations : DomainEntityContainer<Organization>
    {
    }
}
