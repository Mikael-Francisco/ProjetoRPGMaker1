using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Impl;
using BLL.Interfaces;
using DAO;
using DAO.Impl;
using DAO.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RPGMaker
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
            services.AddTransient<IRaceService, RaceService>();
            services.AddTransient<IRaceRepository, RaceRepository>();
            services.AddTransient<ICharacterService, CharacterService>();
            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddTransient<ICreatureService, CreatureService>();
            services.AddTransient<ICreatureRepository, CreatureRepository>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<ITerritoryService, TerritoryService>();
            services.AddTransient<ITerritoryRepository, TerritoryRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IClassService, ClassService>();
            services.AddTransient<IClassRepository, ClassRepository>();
            services.AddTransient<IRPGCreatedService, RPGCreatedService>();
            services.AddTransient<iRPGCreatedRepository, RPGCreatedRepository>();

            services.AddDbContextPool<RPGContext>(c => c.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RPGMakerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            //Tentativa Fracassada de popular o Banco :C
           // services.AddScoped<SeedingService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, SeedingService seedingService*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //seedingService.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
