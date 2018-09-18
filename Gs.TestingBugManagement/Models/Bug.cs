using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gs.TestingBugManagement.Models
{
    public class Bug
    {
        [Key]
        public int BugID { get; set; }
        [Required(ErrorMessage = "You must enter {0}")]
        public string BugState { get; set; }
        public virtual ICollection<BugManagement> BugManagements { get; set; }
    }
}
