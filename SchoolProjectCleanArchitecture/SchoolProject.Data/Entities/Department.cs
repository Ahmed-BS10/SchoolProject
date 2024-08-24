using SchoolProject.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public partial class Department
{
    public Department()
    {
        Students = new HashSet<Student>();
        DepartmentSubjects = new HashSet<DepartmetSubject>();
    }

    [Key]
    public int DID { get; set; }
    [StringLength(500)]
    public string DName { get; set; }
    public int? InsManager { get; set; }

    //

    [InverseProperty(nameof(Student.Department))]
    public virtual ICollection<Student> Students { get; set; }

    //
    [InverseProperty("Department")]
    public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }

    //

    [InverseProperty("department")]
    public virtual ICollection<Instructor>? instructors { get; set; }

    //


    [ForeignKey("InsManager")]
    [InverseProperty(nameof(Instructor.DepartmentManage))]
    public virtual Instructor? instructor { get; set; }

}


