using Example05.WebApplication.Models;

namespace Example05.WebApplication.Services
{
    public class StudentService
    {
        private static List<Student> students = new List<Student>();
        public static List<Student> Students()
        {
            if(students.Any()) return students;

            students.Add(new Student() { Id = 1, Name = "Göksel", Surname = "Kalyoncu", Email = "goksel@mail.com", BirthDate = new DateOnly(2000,1,1), Gender = Gender.Male, StudentStatus = StudentStatus.Active});
            students.Add(new Student() { Id = 2, Name = "Kazım", Surname = "Kalyoncu", Email = "kazim@mail.com", BirthDate = new DateOnly(2000,1,1), Gender = Gender.Male, StudentStatus = StudentStatus.Passive});
            students.Add(new Student() { Id = 3, Name = "Kazım Göksel", Surname = "Kalyoncu", Email = "kazim.goksel@mail.com", BirthDate = new DateOnly(2000,1,1), Gender = Gender.Male, StudentStatus = StudentStatus.Active});
            students.Add(new Student() { Id = 4, Name = "Göksel Kazım", Surname = "Kalyoncu", Email = "goksel.kazim@mail.com", BirthDate = new DateOnly(2000,1,1), Gender = Gender.Male, StudentStatus = StudentStatus.Frezee});
            students.Add(new Student() { Id = 5, Name = "Ayşe", Surname = "Fatma", Email = "ayse@mail.com", BirthDate = new DateOnly(2000,1,1), Gender = Gender.Female, StudentStatus = StudentStatus.Frezee});
            students.Add(new Student() { Id = 6, Name = "Leyla", Surname = "Hülya", Email = "leyla@mail.com", BirthDate = new DateOnly(2000,1,1), Gender = Gender.Female, StudentStatus = StudentStatus.Frezee});

            return students;
        }

        public static void AddStudent(Student student)
        {
            int maxId = students.MaxBy(s => s.Id).Id;

            student.Id = maxId + 1;
            students.Add(student);
        }
    }
}
