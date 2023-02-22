using HotChocolate.Execution.Configuration;
using net_graphql.Data.Queries;
using net_graphql.Data.Mutations;
using net_graphql.Repositories;
using net_graphql.Services;

namespace net_graphql
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection builder)
        {
            // Register custom Repos for the superheroes (Could be in a separate file)
            builder.AddScoped<SuperheroRepository, SuperheroRepository>();
            builder.AddScoped<SuperpowerRepository, SuperpowerRepository>();
            builder.AddScoped<MovieRepository, MovieRepository>();

            return builder;
        }

        public static IServiceCollection AddServices(this IServiceCollection builder)
        {
            builder.AddScoped<SuperheroService, SuperheroService>();
            builder.AddScoped<SuperpowerService, SuperpowerService>();
            builder.AddScoped<MovieService, MovieService>();

            return builder;
        }

        public static IRequestExecutorBuilder AddQueryTypes(this IRequestExecutorBuilder builder)
        {
            builder.AddQueryType(q => q.Name("Query"));

            builder.AddType<SuperheroQuery>();
            builder.AddType<SuperpowerQuery>();
            builder.AddType<MovieQuery>();

            return builder;
        }

        public static IRequestExecutorBuilder AddMutationTypes(this IRequestExecutorBuilder builder)
        {
            builder.AddMutationType(q => q.Name("Mutation"));

            builder.AddType<SuperheroMutation>();
            builder.AddType<SuperpowerMutation>();
            builder.AddType<MovieMutation>();

            return builder;
        }
    }
}
