﻿using net_graphql.Models;
using net_graphql.Services;

namespace net_graphql.Data.Queries
{
    [ExtendObjectType("Query")]
    public class SuperpowerQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Superpower> GetSuperpowers([Service] SuperpowerService superpowerService, Guid? superheroId) 
        {
            if (superheroId.HasValue) 
            {
                return superpowerService.Get(s => s.SuperheroId == superheroId.Value);
            } 
            else
            {
                return superpowerService.Get();
            }
        }

        public Superpower GetSuperpower([Service] SuperpowerService superpowerService, Guid id) =>
            superpowerService.GetSingle(id) ?? new Superpower();
    }
}
