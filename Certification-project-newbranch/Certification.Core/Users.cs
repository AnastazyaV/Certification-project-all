using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Certification.Core
{
    public partial class Users
    {
        public Users()
        {
            Results = new HashSet<Results>();
            Teaching = new HashSet<Teaching>();
        }
        [Key]
        public int id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public byte? Role { get; set; }

        public virtual Students Students { get; set; }
        public virtual ICollection<Results> Results { get; set; }
        public virtual ICollection<Teaching> Teaching { get; set; }
    }
}
