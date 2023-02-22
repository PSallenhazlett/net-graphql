using net_graphql.Data;
using net_graphql.Models;

namespace net_graphql.Services
{
    public class MovieService : ServiceBase<Movie>
    {
        public MovieService(ApplicationDbContext context) : base(context)
        {
        }

        public override void PreAddLogic(Movie newObj, Movie passedData)
        {
            newObj.Title = passedData.Title;
            newObj.Description = passedData.Description;
            newObj.Instructor = passedData.Instructor;
            newObj.ReleaseDate = passedData.ReleaseDate;
            newObj.SuperheroId = passedData.SuperheroId;
        }

        public override void UpdateModel(Movie dbModel, Movie model)
        {
            dbModel.Title = model.Title;
            dbModel.Description = model.Description;
            dbModel.Instructor = model.Instructor;
            dbModel.ReleaseDate = model.ReleaseDate;
            dbModel.SuperheroId = model.SuperheroId;
        }
    }
}
