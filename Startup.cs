using ColourAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ColourAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var server = Configuration["DBServer"] ?? "localhost";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "O6gGbVBM2t0JaaNG2Ss5n68ZatpH6R3lzAx13DdRuoIsuMn8d0UyecKhOyczLzkW";

            services.AddDbContext<ColourContext>(options =>
             options.UseSqlServer($"Server={server},{port};Initial Catalog=Colours;User ID={user};Password={password}"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }


        public void Configure(IApplicationBuilder app)
        {

            app.UseMvc();
            PrepDb.PrepPopulation(app);
        }
    }
}