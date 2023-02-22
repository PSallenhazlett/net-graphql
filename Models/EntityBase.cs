using System.ComponentModel.DataAnnotations;

namespace net_graphql.Models
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
