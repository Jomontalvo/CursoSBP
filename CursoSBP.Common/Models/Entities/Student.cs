using CursoSBP.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace CursoSBP.Common.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido.")]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public Gender Gender { get; set; }

        #region Mapping for create or update
        public async Task<bool> MapToStudentEntity(Student s)
        {
            try
            {
                s.Id = Id;
                if (FirstName is not null) 
                    s.FirstName = FirstName;
                if (LastName is not null) 
                    s.LastName = LastName;
                if (BirthDate is not null) 
                    s.BirthDate = BirthDate;
                if (Email is not null)
                    s.Email = Email;
                if (Phone is not null)
                    s.Phone = Phone;
                if (Address is not null)
                    s.Address = Address;
                s.Gender = Gender;
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
