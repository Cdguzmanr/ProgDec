
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.ProgDec.BL.Models
{
    public class Program
    {
        public int Id { get; set; }
        public int DegreeTypeId { get; set; }
        public string? Description { get; set; }
        

        [DisplayName("Degree Name")]
        public string DegreeTypeName { get; set; }

        [DisplayName("Image")]
        public string ImagePath { get; set; }
    }
}
