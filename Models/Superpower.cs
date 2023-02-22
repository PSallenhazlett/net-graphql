using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace net_graphql.Models
{
    public class Superpower : EntityBase
    {

        [Required(ErrorMessage = "The superpower is required")]
        public string SuperPower { get; set; }
        public string Description { get; set; }

        [ForeignKey("SuperheroId")]
        public Guid SuperheroId { get; set; }
        public virtual Superhero Superhero { get; set; }
    }
}
