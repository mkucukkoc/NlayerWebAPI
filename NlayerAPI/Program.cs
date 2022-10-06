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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>),typeof(Service<>));
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

app.Run();
