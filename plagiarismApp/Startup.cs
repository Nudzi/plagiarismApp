using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using plagiarismApp.Database;
using plagiarismApp.Security;
using plagiarismApp.Services;
using plagiarismModel.TableRequests.Documents;
using plagiarismModel.TableRequests.PackageTypes;
using plagiarismModel.TableRequests.Results;
using plagiarismModel.TableRequests.UserAddresses;
using plagiarismModel.TableRequests.UserImages;
using plagiarismModel.TableRequests.UsersPackageTypes;
using plagiarismModel.TableRequests.UsersUserTypes;

namespace plagiarismApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                        }
                });
            });
            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IRequestsService, RequestsService>();
            services.AddScoped<IUserTypesService, UserTypesService>();
            services.AddScoped<IService<plagiarismModel.PackageTypes, PackageTypesSearchRequest>, PackageTypesService>();


            services.AddScoped<ICRUDService<plagiarismModel.UserImages, UserImagesSearchRequest, UserImagesUpsertRequest, UserImagesUpsertRequest>, UserImagesService>();
            services.AddScoped<ICRUDService<plagiarismModel.Results, ResultsSearchRequest, ResultsUpsertRequest, ResultsUpsertRequest>, ResultsService>();
            services.AddScoped<ICRUDService<plagiarismModel.UserAddresses, UserAddressesSearchRequest, UserAddressesUpsertRequest, UserAddressesUpsertRequest>, UserAddressesService>();
            services.AddScoped<ICRUDService<plagiarismModel.UsersPackageTypes, UsersPackageTypesSearchRequest, UsersPackageTypesUpsertRequest, UsersPackageTypesUpsertRequest>, UsersPackageTypesService>();
            services.AddScoped<ICRUDService<plagiarismModel.UsersUserTypes, UsersUserTypesSearchRequest, UsersUserTypesUpsertRequest, UsersUserTypesUpsertRequest>, UsersUserTypesService>();
            services.AddScoped<ICRUDService<plagiarismModel.Documents, DocumentsSearchRequest, DocumentsUpsertRequest, DocumentsUpsertRequest>, DocumentsService>();
            var connection = Configuration.GetConnectionString("plagiarism");
            services.AddDbContext<plagiarismContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();
            app.UseAuthentication();


            app.UseSwagger();
            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
