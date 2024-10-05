using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Data.Contract;

namespace SchoolProject.Data.Entities
{
    public class Student : ISoftDeleteable
    {
        [Key]
        public int StudID { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Name cant ce null or empty")]
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }

        public int? DID { get; set; }
        [ForeignKey("DID")]
        [InverseProperty("Students")]
        public virtual Department? Department { get; set; }

        [InverseProperty("Student")]
        public virtual ICollection<StudentSubject>? StudentsSubjects { get; set; }


        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted {get; set; }
    }

}





