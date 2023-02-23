using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_graphql.Data;
using net_graphql.Models;
using net_graphql.Models.Mutations;
using net_graphql.Services;

namespace net_graphql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : AbstractController<Superhero, CreateSuperhero>
    {
        SuperheroService _superheroService;

        public SuperheroController(SuperheroService superheroService)
        {
            this._superheroService = superheroService;
        }

        protected override ServiceBase<Superhero, CreateSuperhero> LoadService()
        {
            return this._superheroService;
        }
    }
}
