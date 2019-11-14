using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

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

			services.AddScoped<NotificationContext>();

			services.AddMvc(options => options.Filters.Add<NotificationFilter>()).AddFluentValidation(fv => fv
					.RegisterValidatorsFromAssemblyContaining(typeof(PersonHandler))
					.RegisterValidatorsFromAssemblyContaining(typeof(GetPersonQueryHandler)))
				;

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Lista Telefônica API",
					Version = "v1",
					TermsOfService = new Uri("http://localhost:5005/api/person"),
					Contact = new OpenApiContact()
					{
						Name = "Phillipe Roger",
						Email = "phillrog@hotmail.com",
						Url = new Uri("https://github.com/phillrog/")
					},
					Description = "Projeto backend da lista telefônica",
					License = new OpenApiLicense() { Name = "MIT"  , Url = new Uri("https://opensource.org/licenses/MIT") }
				});

				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);

			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors(builder => builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials());
			app.UseMvc();

			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lista Telefônica API V1");
				c.RoutePrefix = string.Empty;
			});
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

			await next();
		}
	}
}
