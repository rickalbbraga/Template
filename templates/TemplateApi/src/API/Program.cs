using API.Configurations.Filters;
using API.Configurations.Middlewares;
using API.Configurations.Swagger.Examples;
using API.IoC;
using Application.Helpers.Configurations;
using Domain.Interfaces.CQS;
using Semear.Context.CommonCore.DomainNotification;
using Semear.Context.CommonCore.Swagger;
using Semear.Context.Logger.Configurations;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var types = new Type[] { typeof(ICommandHandlerWithTResult<,>), typeof(ICommandHandlerWithVoidTResult<>), typeof(IQueryHandlerWithTResult<,>), typeof(IQueryHandlerWithTResultList<,>) };
builder.Services.AddHandlers(types);
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.AddDomainNotification();
builder.Services.AddSemearLogs(builder.Configuration);
builder.Services.AddMvc(options => options.Filters.Add<NotificationsFilter>());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSemearSwagger("NomeDaApiAqui", "Descrição da API aqui");
builder.Services.AddSwaggerExamplesFromAssemblyOf<CreateCustomerCommandExample>();

builder.Services.AddSwaggerGen(conf =>
{
    conf.ExampleFilters();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.AddSemearSwaggerUI("NomeDaApiAqui");
}

app.UseExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
