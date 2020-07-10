using Certification.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Certification.Core
{
    public partial class Teaching
    {
        [Key]
        public int id { get; set; }
        public string LoginLecturer { get; set; }
        public int IdSubject { get; set; }
        public string NGroup { get; set; }

        public virtual Subjects IdSubjectNavigation { get; set; }
        public virtual User LoginLecturerNavigation { get; set; }
        public virtual Groups NGroupNavigation { get; set; }
    }
}
