using net_graphql.Models;

namespace net_graphql.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Get a list of the movies.")]
        public IEnumerable<Movie> GetMovies([Service] ApplicationDbContext context) => context.Movies;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Get a list of superheroes.")]
        public IEnumerable<Superhero> GetSuperheroes([Service] ApplicationDbContext context) => context.Superheroes;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Get a list of superheroes.")]
        public IEnumerable<Superpower> GetSuperpowers([Service] ApplicationDbContext context) => context.Superpowers;
    }
}
