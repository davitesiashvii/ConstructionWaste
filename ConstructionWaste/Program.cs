using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace ConstructionWaste
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var host = CreateHostBuilder(args).Build();
            try 
            { 
                var scope = host.Services.CreateScope();

                var ctx = scope.ServiceProvider.GetRequiredService<ConstructionWasteDBContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                ctx.Database.EnsureCreated();

                var adminRole = new IdentityRole("admin");
                var userRole = new IdentityRole("user");


                if (!ctx.Roles.Any(x => x.Name == "admin"))
                {
                    roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
                }
                if (!ctx.Roles.Any(x => x.Name == "user"))
                {
                    roleManager.CreateAsync(userRole).GetAwaiter().GetResult();
                }


                if (!ctx.Users.Any(x => x.Email == "123@gmail.com"))
                {
                    var adminUser = new AppUser
                    {
                        UserName = "admin",
                        Email = "123@gmail.com",
                    };
                    var rezult = userManager.CreateAsync(adminUser, "pasword").GetAwaiter().GetResult();
                    var result2 = userManager.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }



            host.Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
