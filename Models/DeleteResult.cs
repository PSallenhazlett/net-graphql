namespace net_graphql.Models
{
    public class DeleteResult
    {
        [GraphQLDescription("Boolean representing whether or not the delete was successful or not.")]
        public bool Success { get; set; }

        [GraphQLIgnore]
        public Exception? Exception { get; set; }

        [GraphQLDescription("The error message of the thrown Exception, if not successful.")]
        public string? ErrorMessage 
        { 
            get
            {
                return Exception?.Message ?? null;
            }
        }
    }
}
