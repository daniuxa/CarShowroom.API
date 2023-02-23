using CarShowroom.Bll.Interfaces;
using CarShowroom.Bll.OperationFilters;
using CarShowroom.Bll.Services;
using CarShowroom.Dal.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using System.Text.Json.Serialization;

//TODO:
//3) Add API security
//4) Add a mail service
//5) Add tests
//6) Make a containerisation 

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Host.UseSerilog();

builder.Services.AddControllers(configure =>
{
    configure.ReturnHttpNotAcceptable = true;
    configure.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
    configure.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
    configure.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));

}).AddNewtonsoftJson()
    .AddXmlSerializerFormatters()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("CarShowroomOpenAPISpecification", new()
    {
        Title = "CarShowroom API",
        Version = "v1",
        Description = "Through this API you can access to CarShowroom database and make CRUD operation with entities",
        Contact = new()
        {
            Email = "daniakroos8@gmail.com",
            Name = "Danyil Salivon"
        }
    });

    setupAction.OperationFilter<GetBrandOperationFilter>();

    setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.Load("CarShowroom.API").GetName().Name}.xml"));
    setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.Load("CarShowroom.Bll").GetName().Name}.xml"));
    setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.Load("CarShowroom.Dal").GetName().Name}.xml"));
});
builder.Services.AddDbContext<CarShowroomContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICompaniesService, CompaniesService>();
builder.Services.AddScoped<IEnginesService, EnginesService>();
builder.Services.AddScoped<IBrandsService, BrandsService>();
builder.Services.AddScoped<IAutomobilesService, AutomobilesService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setupAction =>
    {
        setupAction.SwaggerEndpoint("/swagger/CarShowroomOpenAPISpecification/swagger.json", "CarShowroom API");
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
//app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
