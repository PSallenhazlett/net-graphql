using System.ComponentModel.DataAnnotations;

namespace net_graphql.Models
{
    public class Superhero : EntityBase
    {

        [Required(ErrorMessage = "Please specify a name for the superhero")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Height { get; set; }

        [UseSorting]
        public ICollection<Superpower> Superpowers { get; set; }
        
        [UseSorting]
        public ICollection<Movie> Movies { get; set; }
    }
}
