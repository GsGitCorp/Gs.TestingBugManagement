using System;
using System.ComponentModel.DataAnnotations;

namespace Gs.TestingBugManagement.Models
{
    public class BugManagement
    {
        public BugManagement()
        {

        }

        [Key]
        public int BugNumber { get; set; }

        public string AssignedTo { get; set; }

        public string BugState { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
