using System;
using System.Collections.Generic;

namespace Certification.Core
{
    public partial class Results
    {
        public string LoginStudent { get; set; }
        public int IdCertif { get; set; }
        public byte? Mark { get; set; }

        public virtual Certifications IdCertifNavigation { get; set; }
        public virtual Users LoginStudentNavigation { get; set; }
    }
}
