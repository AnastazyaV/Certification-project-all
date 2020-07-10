using System;
using System.Collections.Generic;

namespace Certification.Core
{
    public partial class Subjects
    {
        public Subjects()
        {
            Certifications = new HashSet<Certifications>();
            Teaching = new HashSet<Teaching>();
        }

        public int IdSubject { get; set; }
        public string Name { get; set; }
        public byte? SubjectType { get; set; }

        public virtual ICollection<Certifications> Certifications { get; set; }
        public virtual ICollection<Teaching> Teaching { get; set; }
    }
}
