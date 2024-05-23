
namespace Example01.WebAPI.Library
{
    public class VirtualDb
    {
        private static List<Student> _students;

        public VirtualDb()
        {
            _students = new List<Student>();

            MockupData();
        }

        private void MockupData()
        {
            _students.Add(new() { Id = 1, Name = "Göksel", Surname = "Kalyoncu", Email = "goksel@mail.com" });
            _students.Add(new() { Id = 2, Name = "Hakan", Surname = "Girgin", Email = "hakan@mail.com" });
            _students.Add(new() { Id = 3, Name = "Kerem", Surname = "Özyön", Email = "kerem@mail.com" });
            _students.Add(new() { Id = 4, Name = "Burak", Surname = "Gonca", Email = "burak@mail.com" });
        }

        public Student? Get(int id)
        {
            return _students.Where(s => s.Id == id).SingleOrDefault();
        }

        public int Add(Student student) 
        {
            int id = _students.MaxBy(s => s.Id) is not null ? _students.MaxBy(s => s.Id).Id : 0;
            id++;

            student.Id = id;

            _students.Add(student);

            return id;
        }

        public int Update(int id, Student student)
        {
            Student? orginal = _students.Where(s => s.Id == id).SingleOrDefault();

            orginal.Name = student.Name;
            orginal.Surname = student.Surname;
            orginal.Email = student.Email;

            _students.Remove(orginal);

            _students.Add(student);

            return id;
        }

        public List<Student> GetAll()
        {
            return _students;
        }
    }
}
