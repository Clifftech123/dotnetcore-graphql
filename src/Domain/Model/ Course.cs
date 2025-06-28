using HotChocolate;

namespace dotnetcore_graphql.src.Domain.Model
{
    public class Course
    {
        public Guid? Id { get; private init; }
        public string Title { get; private set; }
        public ICollection<Student> Students { get; set; } 
        public virtual List<CourseModule> Modules { get; private init; }

        public Course(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
            Modules = new List<CourseModule>();
            Students = new List<Student>();
        }

        protected Course()
        {
            Modules = new List<CourseModule>();
            Students = new List<Student>();
        }

        public void AddModule(string moduleTitle)
        {
            if (Modules.Any(m => m.Title == moduleTitle))
                throw new InvalidOperationException($"Course already contains a module with title '{moduleTitle}'");

            Modules.Add(new CourseModule(moduleTitle));
        }

        public void EnrollStudent(Student student)
        {
            if (Students.Any(s => s.Email == student.Email))
                throw new InvalidOperationException($"Student with email '{student.Email}' is already enrolled in this course");

            Students.Add(student);
        }

        [GraphQLIgnore]
        public CourseModule? GetModule(string title) =>
            Modules.FirstOrDefault(m => m.Title == title);
    }
}
