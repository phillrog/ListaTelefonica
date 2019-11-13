
using System;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using ListaTelefonica.API.Mappings;
using ListaTelefonica.Applications.Core;
using ListaTelefonica.Applications.Handler;
using ListaTelefonica.Infra.CrossCutting.IoC;
using ListaTelefonica.Infra.CrossCutting.Provider;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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

			services.RegisterServicesProvider(Configuration);

			services.RegisterServicesIoC();

			services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

			services.AddMediatR(typeof(PersonHandler).Assembly);
			services.AddMediatR(typeof(GetPersonByIdQueryHandler).Assembly);

			services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailRequestBehavior<,>));
			
			services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(typeof(PersonHandler))
				.RegisterValidatorsFromAssemblyContaining(typeof(GetPersonByIdQueryHandler)));

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
