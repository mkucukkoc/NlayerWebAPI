using Microsoft.EntityFrameworkCore;
using NLayerCore.Repositories;
using NLayerCore.Servicess;
using NLayerCore.UnitOfWork;
using NLayerRepository;
using NLayerRepository.Repositories;
using NLayerRepository.UnitOfWork;
using NLayerService.Mapping;
using NLayerService.Services;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using NLayerService.Validations;
using NlayerAPI.Middlewares;
using NlayerAPI.Filters;
using Autofac;
using NlayerAPI.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Services.AddAutoMapper(typeof(MapProfile));


//Aşagıdaki 7 satırlık olan kod ile migration yapılacak database yolunu ve hangi solution dan yapacagını vermiş olduk.
/*builder.Services.AddDbContext<AppDbContext>(x=>//Bu satırda hangi class dan alacagımı belirledik.
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"),option=>//NLayerAPI içinde olan appsetting.json da olan connection stringi buraya verdik:
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);//bu satırda ise assembly kullanarak hangi solution da migration yapacagımı belieledik 
    });                                                //typeof kullanmamızın sebebi ise classı belirtik ve bu class olur da başka yere taşınır yine bu class dan alsın diye belirtik.
});*/

builder.Services.AddDbContext<AppDbContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UserCustomException();
app.UseAuthorization();

app.MapControllers();

app.Run();
