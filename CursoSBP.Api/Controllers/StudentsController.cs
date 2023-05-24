using CursoSBP.Common.Models.Entities;
using CursoSBP.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CursoSBP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _std;
        public StudentsController(IStudentsService std)
        {
            _std = std;
        }

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Student>))]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var listaResultado = await _std.GetStudentListAsync();
                return Ok(listaResultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get a student by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Student Object</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudent(int id)
        {
            try
            {
                var student = await _std.GetStudentAsync(id);
                return (student == null)
                    ? NotFound("Estudiante no existe!")
                    : Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create a new student.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> PostStudent([FromBody] Student student)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Model invalid");
                bool successAdd = await _std.AddStudentAsync(student);
                return (successAdd)
                    ? CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student)
                    : BadRequest("Can't add a new student.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update a student by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutStudent(int id, [FromBody] Student student)
        {
            if (id != student.Id) return BadRequest();
            bool isUpdated = await _std.UpdateStudentAsync(id, student);
            return (isUpdated)
                ? Accepted(await _std.GetStudentAsync(id))
                : NotFound();
        }

        /// <summary>
        /// Delete a student.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            bool sucessDelete = await _std.DeleteStudentAsync(id);
            return (sucessDelete) ? NoContent() : NotFound();
        }
    }
}
