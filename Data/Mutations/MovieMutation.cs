using net_graphql.Models.Mutations;
using net_graphql.Models;
using net_graphql.Services;

namespace net_graphql.Data.Mutations
{
    [ExtendObjectType("Mutation")]
    public class MovieMutation
    {
        public async Task<Movie> AddMovie([Service] MovieService movieService, CreateMovie movie)
        {
            return await movieService.Add(movie);
        }

        public async Task<Movie> UpdateMovie([Service] MovieService movieService, Movie movie)
        {
            return await movieService.Update(movie);
        }

        public async Task<Movie> DeleteMovie([Service] MovieService movieService, Guid id)
        {
            await movieService.Delete(id);
            return new Movie();
        }
    }
}
