namespace WebAPI
{
    using Alterdata.Bimer.WebAPI.IoC;
    using core.Repository.Context;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using web.api.Configuracao;

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
            services.Configure<JwtConfiguracao>(Configuration.GetSection("Jwt"));
            var jwt = Configuration.GetSection("Jwt").Get<JwtConfiguracao>();

            services.AddControllers();

            services.InjetarDependenciasCore(Configuration, jwt);

            services.InjetarSwagger();
            
            services.Auth(jwt);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
              app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();


            app.UseSwagger();

            app.UseSwaggerUI(c => {
                    c.RoutePrefix = string.Empty;
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api "); 
                    }); 


            app.UseCors(c => c.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            MigracaoInicial(app);
        }


        private static void MigracaoInicial(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<APIClienteContext>())
                {
                    context.Database.Migrate();
                }

            }
        }
    }
}