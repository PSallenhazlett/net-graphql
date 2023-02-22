using net_graphql.Models;
using net_graphql.Services;

namespace net_graphql.Data.Queries
{
    [ExtendObjectType("Query")]
    public class MovieQuery
    {
        public IEnumerable<Movie> GetMovies([Service] MovieService movieService) =>
            movieService.Get();

        public Movie GetMovie([Service] MovieService movieService, Guid id) =>
            movieService.GetSingle(id) ?? new Movie();
    }
}
