using CursoSBP.Common.Models.Entities;

namespace CursoSBP.Data.Interfaces
{
    public interface IStudentsService
    {
        Task<IEnumerable<Student>?> GetStudentListAsync();
        Task<Student?> GetStudentAsync(int id);
        Task<bool> AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(int id, Student student);
        Task<bool> DeleteStudentAsync(int id);
    }
}
