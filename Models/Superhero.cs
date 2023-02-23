using System.ComponentModel.DataAnnotations;

namespace net_graphql.Models
{
    [GraphQLDescription("Superheroes.")]
    public class Superhero : EntityBase
    {

        [GraphQLDescription("The Name of the Superhero.")]
        [Required(ErrorMessage = "Please specify a name for the superhero")]
        public string Name { get; set; }

        [GraphQLDescription("A decription of the Superhero.")]
        public string Description { get; set; }

        [GraphQLDescription("How tall the superhero is.")]
        public double Height { get; set; }

        [GraphQLDescription("The Superheroes' super powers.")]
        [UseSorting]
        public virtual ICollection<Superpower> Superpowers { get; set; }

        [GraphQLDescription("The movies the superhero is in.")]
        [UseSorting]
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
