using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using FinalProjectBkEndApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Text;

namespace FinalProjectBkEndApi
{
    public class Startup
    {
        string AllowOrigins = "_allowOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            #region default configuration
            services.AddControllers().AddNewtonsoftJson(json=>json.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<RestaurantDbContext>(option => option.UseSqlServer("server=.;database=SeaFoodRestaurant;trusted_connection=true"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinalProjectBkEndApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
            #endregion

            #region   configuration for jwt
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
            #endregion

            #region Cors policy for api
            services.AddCors(options =>
            {
                options.AddPolicy(AllowOrigins, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            #endregion

            #region Scrop injection services
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IBill<PurchasesSalesModel>, PurchasesServices>();
            services.AddScoped<IExpenses<ExpensesModel>, ExpensesServices>();
            services.AddScoped<ItemsServices, ItemsServices>();
            services.AddScoped<ProductServices, ProductServices>();
            services.AddScoped<IGenericServices<IParentModel,UserModel>, UserServices>();
            services.AddScoped<CategoryServices, CategoryServices>();
            #endregion

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinalProjectBkEndApi v1"));
            }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider
                  (Path.Combine(Directory.GetCurrentDirectory(), "Uploads",
                  Directory.GetCurrentDirectory(), "Uploads")),
                RequestPath = "/Uploads",

            });


            app.UseRouting();

            app.UseCors(AllowOrigins);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #endregion


        }
    }
}
