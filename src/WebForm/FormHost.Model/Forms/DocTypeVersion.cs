using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormHost.Model.Base;

namespace FormHost.Model.Forms
{
    public class DocTypeVersion : IDomainEntity
    {
        public int Id { get; set; }
        public string VersionString { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public bool IsLast { get; set; }
        public bool Active { get; set; }

        public DocumentType DocumentType { get; set; }
    }

    public class DocTypeVersions : DomainEntityContainer<DocTypeVersion>
    {
    }
}
