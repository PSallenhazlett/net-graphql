using System.ComponentModel.DataAnnotations;

namespace net_graphql.Models.Mutations
{
    public class CreateSuperhero
    {
        [Required(ErrorMessage = "Please specify a name for the superhero")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Height { get; set; }

        public ICollection<Superpower>? Superpowers { get; set; }

        public ICollection<Movie>? Movies { get; set; }
    }
}
