using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace net_graphql.Models.Mutations
{
    public class CreateSuperpower
    {
        [Required(ErrorMessage = "The superpower is required")]
        public string SuperPower { get; set; }
        public string Description { get; set; }

        [ForeignKey("SuperheroId")]
        public Guid SuperheroId { get; set; }
    }
}
