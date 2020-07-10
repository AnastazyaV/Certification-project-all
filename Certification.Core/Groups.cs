using System;
using System.Collections.Generic;

namespace Certification.Core
{
    public partial class Groups
    {
        public Groups()
        {
            Certifications = new HashSet<Certifications>();
            Students = new HashSet<Students>();
            Teaching = new HashSet<Teaching>();
        }

        public string NGroup { get; set; }
        public string Field { get; set; }
        public byte? Course { get; set; }

        public virtual ICollection<Certifications> Certifications { get; set; }
        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<Teaching> Teaching { get; set; }
    }
}
