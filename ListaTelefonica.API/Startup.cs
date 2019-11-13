
using System;
using System.Net;
using System.Threading.Tasks;
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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;


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
			services.AddMediatR(typeof(GetPersonQueryHandler).Assembly);

			//services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailRequestBehavior<,>));

			services.AddScoped<NotificationContext>();

			services.AddMvc(options => options.Filters.Add<NotificationFilter>()).AddFluentValidation(fv => fv
					.RegisterValidatorsFromAssemblyContaining(typeof(PersonHandler))
					.RegisterValidatorsFromAssemblyContaining(typeof(GetPersonQueryHandler)))
				;



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

	public class NotificationFilter : IAsyncResultFilter
	{
		private readonly NotificationContext _notificationContext;

		public NotificationFilter(NotificationContext notificationContext)
		{
			_notificationContext = notificationContext;
		}

		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			if (_notificationContext.HasNotifications)
			{
				context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
				context.HttpContext.Response.ContentType = "application/json";

				var notifications = JsonConvert.SerializeObject(_notificationContext.Notifications);
				await context.HttpContext.Response.WriteAsync(notifications);

				return;
			}

			/// Ajuste para não chunka o response
			context.HttpContext.Response.Headers.Add("Allow", "GET, POST, DELETE, PUT");
			context.HttpContext.Response.ContentType = "application/json";

			var result = JsonConvert.SerializeObject((context.Result as OkObjectResult).Value );
			await context.HttpContext.Response.WriteAsync(result);


			await next();
		}
	}
}
