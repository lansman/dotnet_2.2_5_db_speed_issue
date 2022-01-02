using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dotnet5AspnetSimple
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        public Startup(IWebHostEnvironment webHostEnvironment)
        {
        }

        //public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
       
            services.AddDbContext<MyDbContext>(ReadSettings);
            services.AddScoped<MyDbOptionsReader>();
        }

        private void ReadSettings(IServiceProvider provider, DbContextOptionsBuilder builder)
        {
            var dbOptionsReader = provider.GetRequiredService<MyDbOptionsReader>();
            
            // uncomment one of the lines below
            
            // no problem
            // builder.UseNpgsql(dbOptionsReader.ReadConnectionString());
            
            // there is problem
            builder.UseNpgsql(dbOptionsReader.ReadConnectionString(),
                opts => { opts.ProvideClientCertificatesCallback(dbOptionsReader.AddSslCertificate); });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void AddQueriesDelay(int sqlDelayMsec)
        {
            // placeholder
        }
    }
}