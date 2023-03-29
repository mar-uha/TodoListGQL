using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddPooledDbContextFactory<ApiDbContext>(options =>
    options.UseSqlite("DataSource=app.db; Cache=Shared"));


services.AddGraphQLServer()
    .RegisterDbContext<ApiDbContext>(DbContextKind.Pooled)
    .AddQueryType<Query>();

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});


app.MapGet("/", () => "Hello World!");

app.Run();
