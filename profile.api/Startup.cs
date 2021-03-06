using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using profile.api.Connectors.Blocking;
using profile.api.Connectors.Followers;
using profile.api.Connectors.Profile;
using profile.api.EntityFramework;
using profile.api.Mappings;
using profile.api.Services.AgeService;
using profile.api.Services.BlockingService;
using profile.api.Services.DTOConverters.NewProfileDTOToProfileModel;
using profile.api.Services.DTOConverters.ProfileModelToProfileDTO;
using profile.api.Services.FollowersService;
using profile.api.Services.LanguageService;
using profile.api.Services.ProfileService;

namespace profile.api {
    public class Startup {
        public Startup(IConfiguration configuration, IHostEnvironment env) {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddEntityFrameworkNpgsql();

            if (Env.IsDevelopment()) {

                DotNetEnv.Env.Load();

                services.AddDbContext<ProfileApiDbContext>(options =>
                    options.UseNpgsql(DotNetEnv.Env.GetString("DbConnectionString")));

            } else {
                services.AddDbContext<ProfileApiDbContext>(options =>
                    options.UseNpgsql(Environment.GetEnvironmentVariable("DbConnectionString")));
            }

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                        Title = "Profile Api",
                        Description = "Api to get profile details ",
                });
            });

            services.AddCors(options => {
                options.AddPolicy("AllowAllOrigins",
                    builder => {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();

            services.AddResponseCaching();
            
            //-----interfaces-----

            //automapper
            services.AddSingleton(mapper);

            //services
            services.AddScoped<IProfileService, ProfileService>();
            services.AddSingleton<ILanguageService, LanguageService>();
            services.AddSingleton<IAgeService, AgeService>();
            services.AddScoped<IFollowersService, FollowersService>();
            services.AddScoped<IBlockingService, BlockingService>();

            //connectors
            services.AddScoped<IProfileConnector, ProfileConnector>();
            services.AddScoped<IFollowersConnector, FollowersConnector>();
            services.AddScoped<IBlockingConnector, BlockingConnector>();

            //converters
            services.AddSingleton<INewProfileToProfileModelConverter, NewProfileToProfileModelConverter>();
            services.AddSingleton<IProfileModelToProfileDTOConverter, ProfileModelToProfileDTOConverter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCaching();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Profile API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors("AllowAllOrigins");

            app.Use((context, next) => {
                context.Response.Headers["Server"] = "https://www.youtube.com/watch?v=6n3pFFPSlW4";
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");

                context.Response.GetTypedHeaders().CacheControl =
                    new CacheControlHeaderValue {
                        NoCache = true
                    };

                return next();
            });

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}