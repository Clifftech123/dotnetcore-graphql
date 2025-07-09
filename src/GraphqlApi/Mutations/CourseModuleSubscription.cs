


using dotnetcore_graphql.src.Data;
using dotnetcore_graphql.src.Domain.Model;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetcore_graphql.src.GraphqlApi
{
    [ExtendObjectType("Subscription")]
    public class CourseModuleSubscription
    {
        [Subscribe]
        [Topic]

        public Task<CourseModule?> OnCourseModuleAdded([EventMessage] Guid id, [FromServices] ApplicationDbContext dbContext,CancellationToken cancellationToken)
        {
          return dbContext.CourseModules.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}