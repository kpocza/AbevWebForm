using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Base;

namespace FormHost.Model.Forms
{
    public class DocumentType : IDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool Active { get; set; }

        public Organization Organization { get; set; }
    }

    public class DocumentTypes : DomainEntityContainer<DocumentType>
    {
    }
}
