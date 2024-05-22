﻿
namespace Example01.WebAPI.Library
{
    public class VirtualDb
    {
        private List<Student> _students;

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

        public void Add(Student student) 
        { 
            _students.Add(student);
        }

        public List<Student> GetAll()
        {
            return _students;
        }
    }
}
