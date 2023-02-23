using System.ComponentModel.DataAnnotations;

namespace net_graphql.Models.Mutations
{
    public class CreateSuperhero
    {
        [Required(ErrorMessage = "Please specify a name for the superhero")]
        [GraphQLDescription("The Name of the Superhero.")]
        public string Name { get; set; }

        [GraphQLDescription("A decription of the Superhero.")]
        public string Description { get; set; }

        [GraphQLDescription("How tall the superhero is.")]
        public double Height { get; set; }

        [GraphQLDescription("The Superheroes' super powers.")]
        public ICollection<Superpower>? Superpowers { get; set; }

        [GraphQLDescription("The movies the superhero is in.")]
        public ICollection<Movie>? Movies { get; set; }
    }
}
