using System;
using System.Collections.Generic;

namespace Certification.Core
{
    public partial class Certifications
    {
        public Certifications()
        {
            Results = new HashSet<Results>();
        }

        public int IdCertif { get; set; }
        public string NGroup { get; set; }
        public int? IdSubject { get; set; }
        public byte? CMonth { get; set; }
        public byte? CYear { get; set; }

        public virtual Subjects IdSubjectNavigation { get; set; }
        public virtual Groups NGroupNavigation { get; set; }
        public virtual ICollection<Results> Results { get; set; }
    }
}
