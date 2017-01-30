using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheBigEvent.Services;
using TheBigEvent.Authentification;
using Microsoft.IdentityModel.Tokens;
using TheBigEvent.Controllers;
using System.Text;
using TheBigEvent.DAL;

namespace TheBigEvent
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            string secretKey = Configuration["JwtBearer:SigningKey"];
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            services.Configure<TokenProviderOptions>(o =>
            {
                o.Audience = Configuration["JwtBearer:Audience"];
                o.Issuer = Configuration["JwtBearer:Issuer"];
                o.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddSingleton(p => new UserServices(Configuration["ConnectionStrings:TheBigEventDB"]));
            services.AddSingleton(p => new EventService(Configuration["ConnectionStrings:TheBigEventDB"]));
            services.AddSingleton(p => new TraiteurService(Configuration["ConnectionStrings:TheBigEventDB"]));
            services.AddSingleton(p => new SalleService(Configuration["ConnectionStrings:TheBigEventDB"]));
            services.AddSingleton(p => new DecoService(Configuration["ConnectionStrings:TheBigEventDB"]));
            services.AddSingleton(p => new MenuService(Configuration["ConnectionStrings:TheBigEventDB"]));
            services.AddSingleton(p => new MessageService(Configuration["ConnectionStrings:TheBigEventDB"]));
            services.AddSingleton(p => new BigSelecteService(Configuration["ConnectionStrings:TheBigEventDB"]));
            services.AddSingleton(p => new InviteService(Configuration["ConnectionStrings:TheBigEventDB"]));
            services.AddSingleton(p => new DateService(Configuration["ConnectionStrings:TheBigEventDB"]));
            services.AddSingleton(p => new ValidationService(Configuration["ConnectionStrings:TheBigEventDB"]));


            services.AddSingleton<TokenService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            string secretKey = Configuration["JwtBearer:SigningKey"];
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            app.UseMiddleware<TokenProviderMiddleware>();

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AuthenticationScheme = JwtBearerAuthentication.AuthenticationScheme,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,

                    ValidateIssuer = true,
                    ValidIssuer = Configuration["JwtBearer:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = Configuration["JwtBearer:Audience"]
                }
            });

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = CookieAuthentication.AuthenticationScheme
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "Login",
                    template: "{controller=Acount}/{action=login}/{id?}");

                routes.MapRoute(
                    name: "Conexion",
                    template: "{controller=Acount}/{action=Conexion}/{id?}");
                routes.MapRoute(
                    name: "Event",
                    template: "{controller=Event}/{action=Event}/{method?}");
            });
        }
    }
}
