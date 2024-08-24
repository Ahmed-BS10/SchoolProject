using SchoolProject.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Subjects
{
    public Subjects()
    {
        StudentsSubjects = new HashSet<StudentSubject>();
        DepartmetsSubjects = new HashSet<DepartmetSubject>();
    }


    [Key]
    public int SubID { get; set; }
    [StringLength(500)]
    public string SubjectName { get; set; }
    public DateTime Period { get; set; }

    //

    [InverseProperty("Subject")]
    public virtual ICollection<StudentSubject>? StudentsSubjects { get; set; }

    //

    [InverseProperty("Subjects")]
    public virtual ICollection<DepartmetSubject>? DepartmetsSubjects { get; set; }

    //

    [InverseProperty(nameof(SubjectInsturctor.Subject))]
    public virtual ICollection<SubjectInsturctor>? SubjectInsturctors { get; set; }
}


