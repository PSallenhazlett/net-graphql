using net_graphql.Data;
using net_graphql.Models;
using net_graphql.Models.Mutations;

namespace net_graphql.Services
{
    public class MovieService : ServiceBase<Movie, CreateMovie>
    {
        public MovieService(ApplicationDbContext context) : base(context)
        {
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
