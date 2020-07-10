using Certification.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Certification.Core
{
    public partial class Students
    {
        [Key]
        public int id { get; set; }
        public string LoginStudent { get; set; }
        public string NGroup { get; set; }

        public virtual User LoginStudentNavigation { get; set; }
        public virtual Groups NGroupNavigation { get; set; }
    }
}
