using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Certifications_Core
{
    public class Certification
    {
        public int  Id { get; set; }
        public string NameOfProfessor { get; set; }
        public DateTime DateOfCertification { get; set; }
        public CertificationGroup Group { get; set; }

    }
}
