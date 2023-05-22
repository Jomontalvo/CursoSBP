using CursoSBP.Common.Models.Entities;
using CursoSBP.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CursoSBP.Data.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly DataContext _ctx;
        private readonly ILogger<StudentsService> _logger;

        public StudentsService(DataContext ctx, ILogger<StudentsService> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        /// <summary>
        /// Add new student with EF
        /// </summary>
        /// <param name="student"></param>
        /// <returns>True if add is success.</returns>
        public async Task<bool> AddStudentAsync(Student student)
        {
            try
            {
                await _ctx.AddAsync(student);
                return (await _ctx.SaveChangesAsync() > 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error attempt saving student.");
                return false;
            }
        }

        /// <summary>
        /// Delete a Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteStudentAsync(int id)
        {
            try
            {
                var std = await _ctx.Students.FindAsync(id);
                if (std == null)
                    return false;
                var result = _ctx.Students.Remove(std);
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error attempt delete student.");
                return false;
            }
        }

        /// <summary>
        /// Get Student by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Student?> GetStudentAsync(int id)
        {
            try
            {
                var student = await _ctx.Students.FindAsync(id);
                return student;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting student.");
                return null;
            }
        }

        /// <summary>
        /// Get Student List
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Student>?> GetStudentListAsync()
        {
            try
            {
                var resultList = await _ctx.Students.ToListAsync();
                return resultList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting student list.");
                return null;
            }
        }

        /// <summary>
        /// Update a student.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<bool> UpdateStudentAsync(int id, Student student)
        {
            try
            {
                if (student.Id > 0 && id == student.Id) //Validate call for update student.
                {
                    Student? stdEntity = await _ctx.Students.FindAsync(id);
                    if (stdEntity is null) return false;
                    await student.MapToStudentEntity(stdEntity);
                    return (await _ctx.SaveChangesAsync() >= 0);
                }
                else return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating student.");
                return false;
            }
        }
    }
}
