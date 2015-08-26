using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ExpertAssessment> Assesments { get; set; }
    }
}
