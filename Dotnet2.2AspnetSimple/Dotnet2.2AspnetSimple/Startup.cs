using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet2._2AspnetSimple
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<MyDbContext>(ReadSettings);
            services.AddScoped<MyDbOptionsReader>();
        }

        private void ReadSettings(IServiceProvider provider, DbContextOptionsBuilder builder)
        {
            var dbOptionsReader = provider.GetRequiredService<MyDbOptionsReader>();
            
            // uncomment one of the lines below
            
            // no problem
            // builder.UseNpgsql(dbOptionsReader.ReadConnectionString());
            
            // still no problem
            builder.UseNpgsql(dbOptionsReader.ReadConnectionString(),
                opts => { opts.ProvideClientCertificatesCallback(dbOptionsReader.AddSslCertificate); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}