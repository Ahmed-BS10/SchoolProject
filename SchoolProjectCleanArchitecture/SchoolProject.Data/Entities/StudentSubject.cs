using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SchoolProject.Data.Entities;

public class StudentSubject
{
    [Key]
    public int StudSubID { get; set; }

    
    public int StudID { get; set; }
    
    public int SubID { get; set; }

    [ForeignKey("StudID")]
    [InverseProperty("StudentsSubjects")]
    public virtual Student? Student { get; set; }

    //

    [ForeignKey("SubID")]
    [InverseProperty("StudentsSubjects")]
    public virtual Subjects? Subject { get; set; }

}


