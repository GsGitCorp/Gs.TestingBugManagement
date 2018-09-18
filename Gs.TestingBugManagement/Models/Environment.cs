using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gs.TestingBugManagement.Models
{
    public class Environment
    {
        [Key]
        public int EnvironmentID { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string EnvironmentType { get; set; }
        public virtual ICollection<BugManagement> BugManagements { get; set; }
    }
}
