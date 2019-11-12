using System;
using System.Collections.Generic;
using System.Text;
using ListaTelefonica.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ListaTelefonica.Infra.CrossCutting.Provider
{
	public static class ProviderBootStrapper
	{
		public static IServiceCollection RegisterServicesProvider(this IServiceCollection services, IConfiguration Configuration)
		{
			var conn = "";

			if(Environment.GetEnvironmentVariable("CONTAINER") == "true")
				conn = Configuration.GetConnectionString("ListaTelefonicaContainer");
			else
				conn = Configuration.GetConnectionString("ListaTelefonicaLocalhost");

			services.AddEntityFrameworkNpgsql()
				.AddDbContext<ListaTelefoneContext>(options =>
					options.UseNpgsql(conn, m => m.MigrationsAssembly("ListaTelefonica.Infra.Data")));

			return services;
		}
	}
}