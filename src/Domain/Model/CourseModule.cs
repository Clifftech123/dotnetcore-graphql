

using dotnetcore_graphql.src.Domain.Enum;

namespace dotnetcore_graphql.src.Domain.Model
{
    public class CourseModule
    {

        public Guid  Id { get; private init; }
        public string Title { get; private set; }
        public ModuleStatus Status { get; private set; }
        public int EstimatedHours { get; private set; }
        public int HoursSpent { get; private set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public CourseModule(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
            Status = ModuleStatus.NotStarted;
            EstimatedHours = 0;
            HoursSpent = 0;
        }

        protected CourseModule() { }

        public void Start()
        {
            if (Status == ModuleStatus.NotStarted)
                Status = ModuleStatus.InProgress;
        }

        public void Complete()
        {
            Status = ModuleStatus.Completed;
        }

        public void LogStudyTime(int hours)
        {
            HoursSpent += hours;
        }

        public void EstimateHours(int hours)
        {
            EstimatedHours = hours;
        }
    }
}
