using Microsoft.AspNetCore.Mvc;
using net_graphql.Models;
using net_graphql.Models.Mutations;
using net_graphql.Services;

namespace net_graphql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpowerController : AbstractController<Superpower, CreateSuperpower>
    {
        SuperpowerService _superpowerService;

        public SuperpowerController(SuperpowerService superpowerService)
        {
            this._superpowerService = superpowerService;
        }

        protected override ServiceBase<Superpower> LoadService()
        {
            return this._superpowerService;
        }

        protected override Superpower MapCreate(CreateSuperpower createModel)
        {
            return new Superpower()
            {
                Description = createModel.Description,
                SuperheroId = createModel.SuperheroId,
                SuperPower = createModel.SuperPower
            };
        }
    }
}
