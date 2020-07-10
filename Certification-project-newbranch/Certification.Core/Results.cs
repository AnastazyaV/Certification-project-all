using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Certification.Core
{
    public partial class Results
    {
        [Key]
        public int id { get; set; }
        public string LoginStudent { get; set; }
        public int IdCertif { get; set; }
        public byte? Mark { get; set; }

        public virtual Certifications2 IdCertifNavigation { get; set; }
        public virtual Users LoginStudentNavigation { get; set; }
    }
}
