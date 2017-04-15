using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlayGround.Data;
using PlayGround.Data.Entity;
using System;
using System.Linq;
using System.Reflection;

namespace PlayGround
{
    public class StartupDev
    {
        public StartupDev(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();


        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DocumentClient client = new DocumentClient(new Uri("https://localhost:8081"),"C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            services.AddSingleton<DocumentClient>(client);
            services.AddDbContext<PlaygroundContext>();
            services.AddScoped<PlaygroundContext>();
            RegisterModels(services, new string[] { "PlayGround" }, "Manager");
            // Add framework services.
            services.AddMvc();
            // ********************
            // Setup CORS
            // ********************
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin(); // For anyone access.
            //corsBuilder.WithOrigins("http://localhost:56573"); // for a specific url. Don't add a forward slash on the end!
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors(builder =>
        builder.WithOrigins("http://localhost:4200", "http://localhost:8080")
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
            app.UseMvc();
        }

        public void RegisterModels(IServiceCollection services, string[] Assemblies, string @NameSpace)
        {
            foreach (var a in Assemblies)
            {
                Assembly loadedAss = Assembly.Load(new AssemblyName(a));

                /*var q = from t in loadedAss.GetTypes()
                        where t.IsClass && !t.Name.Contains("<") && t.Namespace.EndsWith(@NameSpace)
                        select t;*/

                var q = loadedAss.GetTypes().Where(c => c.GetTypeInfo().IsClass && c.Name.EndsWith("Manager"));

                foreach (var t in q.ToList())
                {
                    Type.GetType(t.Name);
                    services.AddTransient(Type.GetType(t.FullName), Type.GetType(t.FullName));

                }
            }
        }
    }
}
