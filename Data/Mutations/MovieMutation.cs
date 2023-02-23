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
        public async Task<Movie> DeleteMovie([Service] MovieService movieService, Guid id)
        {
            await movieService.Delete(id);
            return new Movie()
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
}
