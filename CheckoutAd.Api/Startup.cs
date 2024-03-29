﻿using System;
using System.IO;
using CheckoutAd.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CheckoutAd.Api
{
	/// <summary>
	/// Startup class of .netcore project.
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="configuration"></param>
		public Startup(IConfiguration configuration)
		{
			// Init Serilog configuration
			Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
			Configuration = configuration;
		}

		/// <summary>
		/// Configuration property
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
				{
					Version = "v1",
					Title = "Checkout Ad Api Documentation",
					Description = "This documentation provide the information about check out ad api endpoints.",
					TermsOfService = "None",
					Contact = new Swashbuckle.AspNetCore.Swagger.Contact()
					{
						Name = "Salman Tariq Lone",
						Email = "salman@tutorial.com",
						Url = ""
					}
				});
			});
			services.AddSwaggerGen(c =>
			{
				c.IncludeXmlComments(GetXmlCommentsPath());
				c.DescribeAllEnumsAsStrings();
			});
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		/// <param name="loggerFactory"></param>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// logging
			app.UseMiddleware<CustomExceptionMiddleware>();
			loggerFactory.AddSerilog();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Checkout Ad Api");
			});
			app.UseMvc();
		}

		private string GetXmlCommentsPath()
		{
			return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CheckoutAd.Api.xml");
		}
	}
}
