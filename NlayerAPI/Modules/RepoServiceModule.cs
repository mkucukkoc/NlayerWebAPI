using Autofac;
using NLayerCore.Repositories;
using NLayerCore.Servicess;
using NLayerCore.UnitOfWork;
using NLayerRepository;
using NLayerRepository.Repositories;
using NLayerRepository.UnitOfWork;
using NLayerService.Mapping;
using NLayerService.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace NlayerAPI.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           
            //Generic sınıfları aşagıdakı gibi eşleştiriyotruz.Fakat unitofwork bir generic degil onu elle yazmamızın sebebi
            //tek bir eşleştirme olduğu için o yüzden yoksa eger repository gibi veya service gibi birden çok olsaydı onu da 
            //en aşagıda builder edebiliriz.
            
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            
            
            
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            //burada repository ile biten interface ve sınıfları eşleştiriyor ve bunu yapmamızın sebebi 100 tane veri repository ile bitebilir
            //biz bunları tek tek yapmamıza gerek yok.işte bu yüzden autofac kullanıtyoruz.AŞGIDAKİ service de aynı şekildedir.
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();


            //Aşagıdaki kodlar program.cs deki kodlar eğer yukarıdaki kodları yazmasaydık aşagıdakileri program.cs içinde yazacaktık.
            //builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            //builder.Services.AddScoped<ICategoryService, CategoryService>();
            //builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

        }

    }
}
