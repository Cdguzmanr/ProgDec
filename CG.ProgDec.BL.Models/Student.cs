using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.ProgDec.BL.Models
{
    public class Student
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("First Name")]
        public string? LastName { get; set;}

        [DisplayName("Student Id")]
        public string? StudentId { get; set; }

        //[DisplayName("Full Name")]
        public string? FullName { get {  return LastName + " " + FirstName; } }

        public List<Advisor> Advisors { get; set; } = new List<Advisor>(); // By instantianing as "List = new()" we are creating the object. It could be empty, but does exists. We avoid the null error.
    }
}
