using System.Collections.Generic;

namespace LiveEFCoreTeste.Entities
{
    public class School
    {
        public School() { }

        public School(int id, string name)
        {
            Id = id;
            Name = name;

            Active = true;
        }

        public School(string name)
        {
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }
        public ContactInformation ContactInformation { get; set; }

        public List<Student> Students { get; set; }

        public void AddStudent(string name)
        {
            Students.Add(new Student(name));
        }

        public void AddContactInformation(string fullAddress)
        {
            ContactInformation = new ContactInformation(fullAddress, "12345");
        }
    }
}
