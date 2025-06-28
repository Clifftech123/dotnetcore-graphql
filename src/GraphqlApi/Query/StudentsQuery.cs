
using dotnetcore_graphql.src.Data;
using dotnetcore_graphql.src.Domain.Contracts;
using dotnetcore_graphql.src.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcore_graphql.src.GraphqlApi.Common
{

    [ExtendObjectType("Query")]
    public class StudentsQuery
    {
        public  IQueryable<Student> GetStudents([FromServices] ApplicationDbContext dbContext, StudentSearchCriteria filter)
        {
            var query = dbContext.Students.AsQueryable();

            if (filter?.Name != null)
            {
                query = query.Where(s => s.FullName.Contains(filter.Name));
            }
             
             if (filter?.Email != null)
             {
                query = query.Where(s => s.Email.Contains(filter.Email));
             }
           
            return query;
        }

    }
}