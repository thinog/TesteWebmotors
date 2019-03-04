using SimpleInjector;
using TesteWebmotors.Domain.Interfaces.Context;
using TesteWebmotors.Domain.Interfaces.Repositories;
using TesteWebmotors.Domain.Interfaces.Services;
using TesteWebmotors.Domain.Services;
using TesteWebmotors.Infrastructure.Context;
using TesteWebmotors.Infrastructure.Repositories;

namespace TesteWebmotors.UI.IoC
{
    public static class IoC
    {
        public static Container Container { get; set; }


        public static Container Registrar()
        {
            Container container = new Container();

            container.Register<ITesteWebmotorsContext, TesteWebmotorsContext>(Lifestyle.Singleton);
            container.Register<IAnuncioRepository, AnuncioRepository>();
            container.Register<IAnuncioService, AnuncioService>();
            container.Register<IConsultaAPIService, ConsultaAPIService>();

            container.Verify();

            Container = container;

            return container;
        }
    }
}