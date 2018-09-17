using System;
using System.ComponentModel.DataAnnotations;

namespace Gs.TestingBugManagement.Models
{
    public class BugManagement
    {

        [Key]
        [Required]
        public int BugNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string AssignedTo { get; set; }

        [Required]
        [MaxLength(50)]
        public string BugState { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

    }
}
