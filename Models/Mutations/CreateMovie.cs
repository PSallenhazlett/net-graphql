using System.ComponentModel.DataAnnotations.Schema;

namespace net_graphql.Models.Mutations
{
    public class CreateMovie
    {
        [GraphQLDescription("The title of the movie.")]
        public string Title { get; set; }

        [GraphQLDescription("A description of the movie.")]
        public string Description { get; set; }

        [GraphQLDescription("The person who directed the movie.")]
        public string Instructor { get; set; }

        [GraphQLDescription("The date the movie was released.")]
        public DateTime ReleaseDate { get; set; }

        [GraphQLDescription("The id of the Superhero that is in the movie.")]
        public Guid SuperheroId { get; set; }
    }
}
