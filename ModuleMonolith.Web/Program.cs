using ErrorOr;
using FastEndpoints;
using FastEndpoints.Swagger;
using MediatR;
using ModuleMonolith.Framework.Common;
using ModuleMonolith.Framework.Data;
using ModuleMonolith.Framework.Data.PostgreSQL;
using ModuleMonolith.Framework.Routes;
using ModuleMonolith.ModuleOne.Contacts.Implementation;
using ModuleMonolith.ModuleOne.Data.PostgreSQL;
using ModuleMonolith.Web;
using System.Reflection;
using System.Runtime.Loader;

var builder = WebApplication.CreateBuilder(args);

#region Modules

builder.Services.RegisterModule<FrameworkDataModule>(builder.Configuration);
builder.Services.RegisterModule<FrameworkDataPostgreSQLModule>(builder.Configuration);

builder.Services.RegisterModule<ModuleOneContactModule>(builder.Configuration);
builder.Services.RegisterModule<ModuleOneDataPostgreSQLModule>(builder.Configuration);

#endregion

var useCaseAssemblies = GetAssemblies("ModuleMonolith*UseCases.dll");
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(useCaseAssemblies));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(DbTransactionPipelineBehavior<,>));

var routesAssemblies = GetAssemblies("ModuleMonolith*Routes.dll");
builder.Services
    .AddFastEndpoints(o =>
    {
        o.Assemblies = routesAssemblies;
        o.DisableAutoDiscovery = true;
        o.IncludeAbstractValidators = true;
    })
    .SwaggerDocument();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseFastEndpoints(c =>
{
    c.Errors.ResponseBuilder = (validationerrors, context, statucCode) =>
    {
        var errors = validationerrors
            .ConvertAll(error => Error.Validation(
                code: error.PropertyName,
                description: error.ErrorMessage));

        return errors[0].ToResponseError();
    };
})
   .UseSwaggerGen();
app.Run();

static Assembly[] GetAssemblies(string searchPattern)
{
    var location = Assembly.GetExecutingAssembly().Location;
    var assemblies = Directory.EnumerateFiles(Path.GetDirectoryName(location)!, searchPattern)
                    .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                    .ToArray();
    return assemblies;
}