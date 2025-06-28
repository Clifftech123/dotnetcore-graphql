
namespace dotnetcore_graphql.src.Domain.Model
{
    public class Student
    {
        public Guid? Id { get; private init; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public ICollection<Course> Courses { get; set; }

        public Student(string fullName, string email)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
        }

        protected Student() { }
    }
}