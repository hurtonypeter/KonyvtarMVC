using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KonyvtarMVC.Dal;
using KonyvtarMVC.Dal.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using KonyvtarMVC.Web.Infrastructure.Auth;
using Autofac;
using KonyvtarMVC.Web.Bootstrap.AutofacModules;
using KonyvtarMVC.Web.Bootstrap.Swagger;

namespace KonyvtarMVC.Web.Bootstrap
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
            const string issuer = "http://localhost:5000";
            const string token = "tokentokentokentokentokentokentokentokentokentokentokentokentokentokentokentokentokentokentokentokentokentokentokentokentoken";

            //services.AddDbContext<BookStoreContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
            //        opt => opt.MigrationsAssembly("KonyvtarMVC.Dal")));
            services.AddDbContext<BookStoreContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BookStoreContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token)),
                    ValidateAudience = false,
                    ValidIssuer = issuer
                };
                    
            });

            services.Configure<SecurityTokenOptions>(opt =>
            {
                opt.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token)), SecurityAlgorithms.HmacSha256);
                opt.Issuer = issuer;
            });

            services.AddTransient<JwtSecurityTokenHandler>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddMvc();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "KonyvtarMVC.Web.Api", Version = "v1" });
                opt.DescribeAllEnumsAsStrings();
                opt.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });
        }

        /// <summary>
        /// Configuration method hook for container config
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new WebAutofacModule());
            builder.RegisterModule(new DalAutofacModule());
            builder.RegisterModule(new BllAutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env,
            BookStoreContext context,
            UserManager<User> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors("CorsPolicy");

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "KonyvtarMvc.Web.Api v1");
            });

            if (!context.Users.Any())
            {
                var result = userManager.CreateAsync(new User
                {
                    UserName = "hurtonypeter",
                    Email = "hurtonypeter@gmail.com",
                    Name = "Hurtony Péter"
                }, "Asdf123.").Result;
            }
        }
    }
}
