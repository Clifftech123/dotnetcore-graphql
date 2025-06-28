

using dotnetcore_graphql.src.Data;
using dotnetcore_graphql.src.Domain.Model;
using HotChocolate.Types;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcore_graphql.src.GraphqlApi
{

    [ExtendObjectType("Query")]
    public   class CourseQuery
    {
        [UsePaging]
        [UseProjection]
        [HotChocolate.Data.UseFiltering]
        [HotChocolate.Data.UseSorting]
        public  IQueryable<Course> GetCourses([FromServices] ApplicationDbContext dbContext) =>
        dbContext.Courses.AsQueryable();


        public static IQueryable<CourseModule> GetCourseModule([FromServices] ApplicationDbContext dbContext) =>
        dbContext.CourseModules.AsQueryable();
      

    }
}