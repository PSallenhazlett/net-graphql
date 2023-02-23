using System.ComponentModel.DataAnnotations;

namespace net_graphql.Models
{
    public class EntityBase
    {
        [Key]
        [GraphQLDescription("The unique id.")]
        public Guid Id { get; set; }
    }
}
