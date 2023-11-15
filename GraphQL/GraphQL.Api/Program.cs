using GraphQL.Api.GraphTypes.Mutations.InputTypes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
    .AddDbContext<ApplicationDbContext>()
    .AddEndpointsApiExplorer();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
        .AddTypeExtension<UserQuery>()
    
    .AddMutationType(d => d.Name("Mutation"))
        .AddTypeExtension<PostMutation>()
        .AddType<AddPostInputType>()
    
    .AddType<UserType>()
    .AddType<PostType>()
    .AddType<CommentType>()
    
    .AddProjections()
    .RegisterDbContext<ApplicationDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) { }

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGraphQL();
app.UseGraphQLVoyager("/ui/voyager");
app.Seed();
app.Run();