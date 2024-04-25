using System.ComponentModel.DataAnnotations;

namespace Example05.WebApplication.Models
{
    public class TeacherViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }
    }

    public class Teacher
    {
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }
    }
}
