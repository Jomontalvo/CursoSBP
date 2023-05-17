using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoSBP.Common.Models.Entities
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string? SubjectName { get; set; }
        public string? Objects { get; set; }
        public string? TeacherName { get; set; }
        public bool IsActive { get; set; }
    }
}
