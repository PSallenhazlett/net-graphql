using Microsoft.AspNetCore.Mvc;
using net_graphql.Models;
using net_graphql.Models.Mutations;
using net_graphql.Services;

namespace net_graphql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : AbstractController<Movie, CreateMovie>
    {
        public MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            this._movieService = movieService;
        }

        protected override ServiceBase<Movie> LoadService()
        {
            return this._movieService;
        }

        protected override Movie MapCreate(CreateMovie createModel)
        {
            return new Movie()
            {
                Description = createModel.Description,
                Instructor = createModel.Instructor,
                SuperheroId = createModel.SuperheroId,
                ReleaseDate = createModel.ReleaseDate,
                Title = createModel.Title
            };
        }
    }
}
