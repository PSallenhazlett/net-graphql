using HotChocolate.Execution.Configuration;
using net_graphql.Data.Mutations;
using net_graphql.Data.Subscriptions;
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

        public static IRequestExecutorBuilder AddMutationTypes(this IRequestExecutorBuilder builder)
        {
            builder.AddMutationType(q => q.Name("Mutation"));

            builder.AddType<SuperheroMutation>();
            builder.AddType<SuperpowerMutation>();
            builder.AddType<MovieMutation>();

            return builder;
        }

        public static IRequestExecutorBuilder AddSubscriptionTypes(this IRequestExecutorBuilder builder)
        {
            builder.AddSubscriptionType(q => q.Name("Subscription"));

            builder.AddType<SuperheroSubscription>();
            builder.AddType<SuperpowerSubscription>();
            builder.AddType<MovieSubscription>();

            return builder;
        }
    }
}
