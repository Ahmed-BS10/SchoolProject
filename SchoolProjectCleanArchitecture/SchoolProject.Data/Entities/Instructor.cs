using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor 
    {
        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            SubjectInsturctors = new HashSet<SubjectInsturctor>();
        }

        [Key]
        public int InstId { get; set; }

        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public double? Salary { get; set; }
        public int? DID { get; set; }
        public string? ImagePath { get; set; }

        // Money Instructors To One Department

        [ForeignKey("DID")]
        [InverseProperty("instructors")]
        public Department? department { get; set; }


        // Instructor Manger To  Department

        [InverseProperty("instructor")]
        public Department? DepartmentManage { get; set; }


        // Supervisor Manger To  Instructors

        [ForeignKey("SupervisorId")]
        [InverseProperty("Instructors")]
        public Instructor? Supervisor { get; set; }



        // Instructors Manger By   Supervisor
        [InverseProperty("Supervisor")]
        public virtual ICollection<Instructor>? Instructors { get; set; }



        [InverseProperty("Instructor")]
        public ICollection<SubjectInsturctor>? SubjectInsturctors { get; set; }
    }
}
