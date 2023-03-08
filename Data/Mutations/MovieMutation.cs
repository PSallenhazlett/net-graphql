using net_graphql.Models.Mutations;
using net_graphql.Models;
using net_graphql.Services;

namespace net_graphql.Data.Mutations
{
    [ExtendObjectType("Mutation")]
    public class MovieMutation
    {
        [GraphQLDescription("Add a movie by passing the fields needed to create one.")]
        public async Task<Movie> AddMovie([Service] MovieService movieService, CreateMovie movie)
        {
            return await movieService.Add(movie);
        }

        [GraphQLDescription("Update a movie by passing all the fields of one.")]
        public async Task<Movie> UpdateMovie([Service] MovieService movieService, Movie movie)
        {
            return await movieService.Update(movie);
        }

        [GraphQLDescription("Delete a movie by id.")]
        public async Task<DeleteResult> DeleteMovie([Service] MovieService movieService, Guid id)
        {
            var result = new DeleteResult();

            try
            {
                await movieService.Delete(id);
                result.Success = true;
            }
            catch ( Exception ex)
            {
                result.Exception = ex;
                result.Success = false;
            }

            return result;
        }
    }
}
