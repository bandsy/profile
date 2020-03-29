using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using profile.api.Connectors.ProfileConnector;
using profile.api.EntityFramework;
using profile.api.Services.ProfileService;

namespace profile.api {
	public class Startup {
		public Startup (IConfiguration configuration, IHostEnvironment environment) {
			Configuration = configuration;
			Environment = environment;
		}

		public IConfiguration Configuration { get; }
		public IHostEnvironment Environment { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices (IServiceCollection services) {
			services.AddControllers ();
			services.AddEntityFrameworkNpgsql ();

			if (Environment.IsDevelopment ()) {

				DotNetEnv.Env.Load ();

				services.AddDbContext<ProfileApiDbContext> (options =>
					options.UseNpgsql (DotNetEnv.Env.GetString ("DbConnectionString")));

			} else {
				services.AddDbContext<ProfileApiDbContext> (options =>
					options.UseNpgsql (Configuration.GetValue<string> ("ConnetionStrings:DbConnectionString")));
			}

			services.AddSwaggerGen (c => {
				c.SwaggerDoc ("v1", new OpenApiInfo {
					Version = "v1",
						Title = "Profile Api",
						Description = "Api to get profile details ",
				});
			});

			services.AddCors (options => {
				options.AddPolicy ("AllowAllOrigins",
					builder => {
						builder.AllowAnyOrigin ()
							.AllowAnyMethod ()
							.AllowAnyHeader ();
					});
			});

			//-----interfaces------

			//services
			services.AddSingleton<IProfileService, ProfileService> ();

			//connectors
			services.AddSingleton<IProfileConnector, ProfileConnector> ();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment ()) {
				app.UseDeveloperExceptionPage ();
			}

			app.UseHttpsRedirection ();

			app.UseRouting ();

			app.UseAuthorization ();

			app.UseSwagger ();
			app.UseSwaggerUI (c => {
				c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Profile API V1");
				c.RoutePrefix = string.Empty;
			});

			app.UseCors ("AllowAllOrigins");

			app.UseEndpoints (endpoints => {
				endpoints.MapControllers ();
			});
		}
	}
}