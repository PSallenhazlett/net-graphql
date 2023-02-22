using System.ComponentModel.DataAnnotations.Schema;

namespace net_graphql.Models.Mutations
{
    public class CreateMovie
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Instructor { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Guid SuperheroId { get; set; }
    }
}
