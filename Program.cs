using Microsoft.EntityFrameworkCore;
using net_graphql;
using net_graphql.Data;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add our repositories and services
builder.Services.AddRepositories()
                .AddServices();

// Setup the GraphQL Service
builder.Services.AddGraphQLServer()
                .AddQueryTypes()
                .AddMutationTypes()
                .AddProjections()
                .AddFiltering()
                .AddSorting();

// Get the connection String
var connectionString = configuration.GetConnectionString("SqlServer");

// Add Application Db Context options
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Map the Graph QL Server to the /graphql endpoint
app.MapGraphQL("/graphql", (string?)null);

app.Run();
