using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Certification.Core
{
    public partial class Subjects
    {
        public Subjects()
        {
            Certifications = new HashSet<Certifications2>();
            Teaching = new HashSet<Teaching>();
        }
        [Key]
        public int IdSubject { get; set; }
        public string Name { get; set; }
        public byte? SubjectType { get; set; }

        public virtual ICollection<Certifications2> Certifications { get; set; }
        public virtual ICollection<Teaching> Teaching { get; set; }
    }
}
