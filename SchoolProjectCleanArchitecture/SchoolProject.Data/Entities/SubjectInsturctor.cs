using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class SubjectInsturctor
    {
        [Key]
        public int SubjectInsturctorId { get; set; }
       
        public int SubId { get; set; }
      
        public int InsId { get; set; }


        [ForeignKey("InsId")]
        [InverseProperty(nameof(Instructor.SubjectInsturctors))]
        public Instrctor? Instructor { get; set; }



        [ForeignKey("SubId")]
        [InverseProperty(nameof(Subject.SubjectInsturctors))]
        public Subjects? Subject { get; set; }


    }
}
