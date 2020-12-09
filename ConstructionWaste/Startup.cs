using AutoMapper;
using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Interfaces;
using Services.JoinTables;
using Services.Repositories;

namespace ConstructionWaste
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
            services.AddControllersWithViews();

            services.AddDbContext<ConstructionWasteDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConstructionWasteDB")));

            services.AddIdentity<AppUser, IdentityRole>(opts => {
                opts.Password.RequireDigit = false;
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<ConstructionWasteDBContext>()
                .AddDefaultTokenProviders();

            
            

            services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Auth/Login");
            services.ConfigureApplicationCookie(opts => opts.AccessDeniedPath = "/Auth/AccessDenied");

            services.AddAutoMapper(typeof(ConstructionWaste.Mapper.MapProfile).Assembly);

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IJoinTables, JoinTables>();
            services.AddScoped<IUOW, UOW>();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=Login}/{id?}");
            });
        }
    }
}
