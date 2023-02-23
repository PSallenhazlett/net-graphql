using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace net_graphql.Models
{
    [GraphQLDescription("Movies the Superhero is in.")]
    public class Movie : EntityBase
    {

        [Required(ErrorMessage = "The movie title is required")]
        [GraphQLDescription("The title of the movie.")]
        public string Title { get; set; }

        [GraphQLDescription("A description of the movie.")]
        public string Description { get; set; }

        [GraphQLDescription("The person who directed the movie.")]
        public string Instructor { get; set; }

        [GraphQLDescription("The date the movie was released.")]
        public DateTime ReleaseDate { get; set; }

        [GraphQLDescription("The id of the Superhero that is in the movie.")]
        [ForeignKey("SuperheroId")]
        public Guid SuperheroId { get; set; }

        [GraphQLDescription("The Superhero that is in the movie.")]
        public virtual Superhero Superhero { get; set; }
    }
}
