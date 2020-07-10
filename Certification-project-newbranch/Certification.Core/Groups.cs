using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Certification.Core
{
    public partial class Groups
    {
        public Groups()
        {
            Certifications = new HashSet<Certifications2>();
            Students = new HashSet<Students>();
            Teaching = new HashSet<Teaching>();
        }
        [Key]
        public int id { get; set; }
        public string NGroup { get; set; }
        public string Field { get; set; }
        public byte? Course { get; set; }

        public virtual ICollection<Certifications2> Certifications { get; set; }
        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<Teaching> Teaching { get; set; }
    }
}
