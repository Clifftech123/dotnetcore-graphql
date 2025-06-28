

namespace dotnetcore_graphql.src.Domain.Contracts
{
    public class CourseDTO
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public List<CourseModuleDTO> Modules { get; set; } = new();
        public List<StudentDTO> Students { get; set; } = new();
    }

    public class CourseModuleDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public int EstimatedHours { get; set; }
        public int HoursSpent { get; set; }
        public Guid CourseId { get; set; }
    }

    public class StudentDTO
    {
        public Guid? Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
