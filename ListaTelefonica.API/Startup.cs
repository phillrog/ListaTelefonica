using ListaTelefonica.Infra.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ListaTelefonica.API
{
	public class Startup
	{
		IConfiguration Configuration { get; set; }
		public Startup(IConfiguration configuration)
		{
			var builder = new ConfigurationBuilder().AddJsonFile("config.json");
			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			var conn = Configuration.GetConnectionString("ListaTelefonica");

			services.AddDbContext<ListaTelefoneContext>(option => 
					option.UseSqlServer(conn, m => m.MigrationsAssembly("ListaTelefonica.Infra.Data")));
			services.AddMvcCore();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Hello World!");
				});
			});
		}
	}
}
