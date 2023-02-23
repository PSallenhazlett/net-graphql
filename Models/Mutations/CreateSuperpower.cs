using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace net_graphql.Models.Mutations
{
    public class CreateSuperpower
    {
        [Required(ErrorMessage = "The superpower is required")]
        [GraphQLDescription("The Name of the Super Power.")]
        public string SuperPower { get; set; }

        [GraphQLDescription("A description of the Super Power.")]
        public string Description { get; set; }

        [GraphQLDescription("The id of the superhero that this superpower belongs to.")]
        [ForeignKey("SuperheroId")]
        public Guid SuperheroId { get; set; }
    }
}
