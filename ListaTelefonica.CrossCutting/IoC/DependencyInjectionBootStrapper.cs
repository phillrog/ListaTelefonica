using ListaTelefonica.Applications;
using ListaTelefonica.Applications.Interfaces;
using ListaTelefonica.Applications.UoW;
using ListaTelefonica.Domain.Interfaces.Contexts;
using ListaTelefonica.Domain.Interfaces.Repositories;
using ListaTelefonica.Domain.Interfaces.Services;
using ListaTelefonica.Domain.Services;
using ListaTelefonica.Infra.Data.Contexts;
using ListaTelefonica.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ListaTelefonica.Infra.CrossCutting.IoC
{
	public static class DependencyInjectionBootStrapper
	{
		public static IServiceCollection RegisterServicesIoC(this IServiceCollection services)
		{
			
			services.AddScoped<IContext, ListaTelefoneContext>();

			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
			services.AddScoped<IPersonAppService, PersonAppService>();

			services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
			services.AddScoped<IPersonService, PersonService>();

			services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
			services.AddScoped<IPersonRepository, PersonRepository>();


			return services;
		}
	}
}
