using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Certification.Core
{
    public partial class Certifications2
    {
        public Certifications2()
        {
            Results = new HashSet<Results>();
        }

        [Key]
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
