using Library.WebApi.Api.Middlewares;
using Library.WebApi.BusinessLogic.AutoMapper;
using Library.WebApi.BusinessLogic.Interfaces;
using Library.WebApi.BusinessLogic.Servicios;
using Library.WebApi.BusinessLogic.Util;
using Library.WebApi.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<EmailMessageSetting>(builder.Configuration.GetSection("EmailMessageSetting"));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddTransient<ILibroServicio, LibroServicio>();
builder.Services.AddTransient<IAutorServicio, AutorServicio>();
builder.Services.AddTransient<IRevisionServicio, RevisionServicio>();
builder.Services.AddTransient<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddSingleton<IEmailSender, EmailSender>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services
        .AddControllers()
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "";
    });
}

app.UseRouting();
app.UseMiddleware<HttpContextMiddleware>();
app.MapControllers();

app.Run();

