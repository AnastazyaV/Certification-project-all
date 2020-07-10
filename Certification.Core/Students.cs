using System;
using System.Collections.Generic;

namespace Certification.Core
{
    public partial class Students
    {
        public string LoginStudent { get; set; }
        public string NGroup { get; set; }

        public virtual Users LoginStudentNavigation { get; set; }
        public virtual Groups NGroupNavigation { get; set; }
    }
}
