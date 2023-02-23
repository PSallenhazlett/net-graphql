using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace net_graphql.Models
{
    [GraphQLDescription("Superpowers of the Superheroes.")]
    public class Superpower : EntityBase
    {

        [GraphQLDescription("The Name of the Super Power.")]
        [Required(ErrorMessage = "The superpower is required")]
        public string SuperPower { get; set; }

        [GraphQLDescription("A description of the Super Power.")]
        public string Description { get; set; }

        [GraphQLDescription("The id of the superhero that this superpower belongs to.")]
        [ForeignKey("SuperheroId")]
        public Guid SuperheroId { get; set; }

        [GraphQLDescription("The superhero that this superpower belongs to.")]
        public virtual Superhero Superhero { get; set; }
    }
}
