using ListaTelefonica.Infra.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ListaTelefonica.API
{
	public class Startup
	{

		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			var builder = new ConfigurationBuilder().AddJsonFile("config.json");
			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			var conn = Configuration.GetConnectionString("ListaTelefonica");

			services.AddEntityFrameworkNpgsql()
				.AddDbContext<ListaTelefoneContext>(options => options.UseNpgsql(conn, m => m.MigrationsAssembly("ListaTelefonica.Infra.Data")));
		}
	
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}


			app.UseMvc();
		}
	}
}
