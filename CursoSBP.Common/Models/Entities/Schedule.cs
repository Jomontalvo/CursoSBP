using System.ComponentModel.DataAnnotations;

namespace CursoSBP.Common.Models.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        
        [Key]
        public Student? Student { get; set; }

        [Key]
        public Subject? Subject { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public string? Classroom { get; set; }

    }
}
