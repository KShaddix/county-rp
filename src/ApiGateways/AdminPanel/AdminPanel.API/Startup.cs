using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceSite;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Interfaces;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace CountyRP.ApiGateways.AdminPanel.API
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
            services.AddSingleton(new SupportRequestMessageClient(new HttpClient())
            {
                BaseUrl = "https://localhost:10501"
            });

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            services.AddSingleton(new PlayerClient(new HttpClient(clientHandler))
            {
                BaseUrl = "https://192.168.1.71:49171"
            });

            services.AddSingleton(new PersonClient(new HttpClient(clientHandler))
            {
                BaseUrl = "https://192.168.1.71:49171"
            });

            services.AddTransient<IGameService, GameService>();
            services.AddTransient<ISupportRequestMessageSiteService, SupportRequestMessageSiteService>();

            services.AddControllers();

            services.AddSwaggerDocument(document =>
            {
                document.Title = "County RP AdminPanel Gateway API";
                document.Version = "v1";
                document.Description = "The County RP AdminPanel Gateway API documentation description.";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
