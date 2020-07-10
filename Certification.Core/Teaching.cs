using System;
using System.Collections.Generic;

namespace Certification.Core
{
    public partial class Teaching
    {
        public string LoginLecturer { get; set; }
        public int IdSubject { get; set; }
        public string NGroup { get; set; }

        public virtual Subjects IdSubjectNavigation { get; set; }
        public virtual Users LoginLecturerNavigation { get; set; }
        public virtual Groups NGroupNavigation { get; set; }
    }
}
