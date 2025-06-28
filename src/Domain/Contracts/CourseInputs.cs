

namespace dotnetcore_graphql.src.Domain.Contracts
{
    public class CourseInputs
    {
    public record CreateCourseInput(string Title);
    
    public record AddModuleToCourseInput(string CourseTitle, string ModuleTitle);
    
    public record EnrollStudentInput(string CourseTitle, string StudentFullName, string StudentEmail);
        
    }
}