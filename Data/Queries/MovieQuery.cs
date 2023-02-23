using net_graphql.Models;
using net_graphql.Services;

namespace net_graphql.Data.Queries
{
    [ExtendObjectType("Query")]
    public class MovieQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Get a list of the movies.")]
        public IEnumerable<Movie> GetMovies([Service] ApplicationDbContext context) => context.Movies;

        [GraphQLDescription("Get a single movies by id.")]
        public Movie GetMovie([Service] MovieService movieService, Guid id) =>
            movieService.GetSingle(id) ?? new Movie()
            {   
                Id = Guid.Empty,
                Description = "",
                Instructor = "",
                Title = "",
                ReleaseDate = DateTime.Now,
                SuperheroId = Guid.Empty,
            };
    }
}
