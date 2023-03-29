using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddPooledDbContextFactory<ApiDbContext>(options =>
    options.UseSqlite("DataSource=app.db; Cache=Shared"));


// This will be the entry point and will provide us with a schema 
// construction
services.AddGraphQLServer()
    .RegisterDbContext<ApiDbContext>(DbContextKind.Pooled)
    .AddQueryType<Query>()
    .AddType<ListType>()
    .AddType<ItemType>()
    .AddMutationType<Mutation>()
    .AddProjections()
    .AddSorting()
    .AddFiltering();

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
