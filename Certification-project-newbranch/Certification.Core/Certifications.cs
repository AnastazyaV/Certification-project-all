using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Certification.Core
{
    public class Certifications
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string NameOfProfessor { get; set; }
        public DateTime DateOfCertification { get; set; }
        public GroupsType Group { get; set; }

    }
}