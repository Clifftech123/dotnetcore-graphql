using Microsoft.EntityFrameworkCore;
using dotnetcore_graphql.src.Domain.Contracts;
using dotnetcore_graphql.src.Domain.Model;
using dotnetcore_graphql.src.Data;
using dotnetcore_graphql.src.GraphqlApi.Common;
using static dotnetcore_graphql.src.Domain.Contracts.CourseInputs;
using Microsoft.AspNetCore.Mvc;
using HotChocolate.Subscriptions;

namespace dotnetcore_graphql.src.GraphqlApi.Mutations
{
    [ExtendObjectType("Mutation")]
    public class CourseMutations
    {
        public  async Task<CreateCoursePayload> CreateCourse(
            CreateCourseInput input, 
            [FromServices] ApplicationDbContext dbContext)
        {
            try
            {
                // Check if course with same title already exists
                if (await dbContext.Courses.AnyAsync(c => c.Title == input.Title))
                {
                    return new CreateCoursePayload(new[] 
                    { 
                        new UserError("A course with this title already exists", "COURSE_TITLE_NOT_UNIQUE") 
                    });
                }

                var course = new Course(input.Title);
                dbContext.Courses.Add(course);
                await dbContext.SaveChangesAsync();
                
                return new CreateCoursePayload(course);
            }
            catch (Exception ex)
            {
                return new CreateCoursePayload(
                [
                    new UserError($"Failed to create course: {ex.Message}", "COURSE_CREATION_FAILED") 
                ]);
            }
        }

        public static async Task<AddModulePayload> AddModuleToCourse(
            AddModuleToCourseInput input,
            [FromServices] ApplicationDbContext dbContext,  
            [FromServices] ITopicEventSender eventSender) 
        {
            try
            {
                var course = await dbContext.Courses
                    .Include(c => c.Modules)
                    .SingleOrDefaultAsync(c => c.Title == input.CourseTitle);

                if (course == null)
                {
                    return new AddModulePayload(new[] 
                    { 
                        new UserError($"Course with title '{input.CourseTitle}' not found", "COURSE_NOT_FOUND") 
                    });
                }

                course.AddModule(input.ModuleTitle);
                await dbContext.SaveChangesAsync();
                await eventSender.SendAsync(nameof(CourseModuleSubscription.OnCourseModuleAdded), course.Id);

                return new AddModulePayload(course);
            }
            catch (InvalidOperationException ex)
            {
                return new AddModulePayload(new[] 
                { 
                    new UserError(ex.Message, "MODULE_ALREADY_EXISTS") 
                });
            }
            catch (Exception ex)
            {
                return new AddModulePayload(new[] 
                { 
                    new UserError($"Failed to add module: {ex.Message}", "MODULE_ADDITION_FAILED") 
                });
            }
        }

        public static async Task<EnrollStudentPayload> EnrollStudent(
            EnrollStudentInput input,
            [FromServices] ApplicationDbContext dbContext)
        {
            try
            {
                var course = await dbContext.Courses
                    .Include(c => c.Students)
                    .SingleOrDefaultAsync(c => c.Title == input.CourseTitle);

                if (course == null)
                {
                    return new EnrollStudentPayload(new[] 
                    { 
                        new UserError($"Course with title '{input.CourseTitle}' not found", "COURSE_NOT_FOUND") 
                    });
                }

                // Check if student already exists
                var existingStudent = await dbContext.Students
                    .SingleOrDefaultAsync(s => s.Email == input.StudentEmail);

                Student student;
                if (existingStudent != null)
                {
                    student = existingStudent;
                }
                else
                {
                    student = new Student(input.StudentFullName, input.StudentEmail);
                    dbContext.Students.Add(student);
                }

                course.EnrollStudent(student);
                await dbContext.SaveChangesAsync();

                return new EnrollStudentPayload(course);
            }
            catch (InvalidOperationException ex)
            {
                return new EnrollStudentPayload(new[] 
                { 
                    new UserError(ex.Message, "STUDENT_ALREADY_ENROLLED") 
                });
            }
            catch (Exception ex)
            {
                return new EnrollStudentPayload(new[] 
                { 
                    new UserError($"Failed to enroll student: {ex.Message}", "ENROLLMENT_FAILED") 
                });
            }
        }
    }
}
