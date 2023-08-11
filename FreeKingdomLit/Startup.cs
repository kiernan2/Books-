using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FreeKingdomLit.Models;

namespace FreeKingdomLit
{
  public class Startup
  {
    public IConfigurationRoot Configuration { get; }

    public Startup(IWebHostEnvironment env)
    {
      IConfigurationBuilder builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json");    
      Configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {

      services.AddMvc();
      services.AddEntityFrameworkMySql()
        .AddDbContext<FreeKingdomLitContext>(
          options => options.UseMySql(Configuration["ConnectionStrings:DefaultConnection"],
          ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
    }
    
    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();
      app.UseRouting();

      app.UseEndpoints(routes => 
      {
        routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
      });

      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Hello, I didn't find a route!");
      });
    }
  }
}