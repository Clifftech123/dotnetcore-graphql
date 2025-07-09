

using Microsoft.EntityFrameworkCore;
using dotnetcore_graphql.src.GraphqlApi;
using dotnetcore_graphql.src.Data;
using dotnetcore_graphql.src.GraphqlApi.Mutations;


namespace dotnetcore_graphql.src.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {

            services.AddDbContext< ApplicationDbContext>(opt=> 
    opt.UseSqlite("Data Source=dotnetcore_graphql.db "));

            services
              .AddGraphQLServer()
              .AddQueryType(d => d.Name("Query"))
              .AddTypeExtension<GraphqlApi.Common.StudentsQuery>()
              .AddTypeExtension<CourseQuery>()
              .AddProjections()
              .AddFiltering()
              .AddSorting()
              .AddMutationType(d => d.Name("Mutation"))
              .AddTypeExtension<CourseMutations>()
              .AddInMemorySubscriptions()
              .AddSubscriptionType(d => d.Name("Subscription"))
              .AddTypeExtension<CourseModuleSubscription>();

        }
        

         public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebSockets();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

        }
        
    }
}