
using System;
using System.ComponentModel.DataAnnotations;

namespace Gs.TestingBugManagement.Models
{
    public class BugManagement
    {
        [Key]
        [Required]
        public int BugManagmentId { get; set; }

        [Required]
        public int BugNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string AssignedTo { get; set; }

        [Required, DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Enterprise")]
        public int EnterpriseID { get; set; }
        public virtual Enterprise Enterprise { get; set; }

        [Display(Name = "Environment")]
        public int EnvironmentID { get; set; }
        public virtual Environment Environment { get; set; }

        [Display(Name = "Bug State")]
        public int BugID { get; set; }
        public virtual Bug Bug { get; set; }

    }
}
