
using Shop.Api;


var startup = new Startup(WebApplication.CreateBuilder(args));
startup
    .AddServices()
    .AddServiceGraphQL()
    .AddConfigure()
    .Run();

public partial class Program { }


