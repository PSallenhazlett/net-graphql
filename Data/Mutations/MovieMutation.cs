using net_graphql.Models.Mutations;
using net_graphql.Models;
using net_graphql.Services;
using HotChocolate.Subscriptions;

namespace net_graphql.Data.Mutations
{
    [ExtendObjectType("Mutation")]
    public class MovieMutation
    {
        [GraphQLDescription("Add a movie by passing the fields needed to create one.")]
        public async Task<Movie> AddMovie([Service] MovieService movieService, [Service] ITopicEventSender sender, CreateMovie movie, CancellationToken cancellationToken)
        {
            var newMovie = await movieService.Add(movie);
            await sender.SendAsync(nameof(AddMovie), newMovie, cancellationToken);

            return newMovie;
        }

        [GraphQLDescription("Update a movie by passing all the fields of one.")]
        public async Task<Movie> UpdateMovie([Service] MovieService movieService, [Service] ITopicEventSender sender, Movie movie, CancellationToken cancellationToken)
        {
            var updatedMovie = await movieService.Update(movie);
            await sender.SendAsync(nameof(UpdateMovie), updatedMovie, cancellationToken);

            return updatedMovie;
        }

        [GraphQLDescription("Delete a movie by id.")]
        public async Task<DeleteResult> DeleteMovie([Service] MovieService movieService, [Service] ITopicEventSender sender, Guid id, CancellationToken cancellationToken)
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

            await sender.SendAsync(nameof(DeleteMovie), result, cancellationToken);

            return result;
        }
    }
}
