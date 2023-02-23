using net_graphql.Data;
using net_graphql.Models;
using net_graphql.Models.Mutations;
using net_graphql.Repositories;

namespace net_graphql.Services
{
    public class MovieService : AbstractService<Movie, CreateMovie>
    {
        MovieRepository _movieRepository;

        public MovieService(MovieRepository movieRepository)
        {
            this._movieRepository = movieRepository;
        }

        protected override AbstractRepository<Movie> LoadRepository()
        {
            return this._movieRepository;
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

        protected override void UpdateModel(Movie dbModel, Movie model)
        {
            dbModel.Title = model.Title;
            dbModel.Description = model.Description;
            dbModel.Instructor = model.Instructor;
            dbModel.ReleaseDate = model.ReleaseDate;
            dbModel.SuperheroId = model.SuperheroId;
        }
    }
}
