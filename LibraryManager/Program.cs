using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Seeding;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateWebHostBuilder(args).Build(); //.Run();

            using (var scope = builder.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<LibraryManagerContext>();

                //context.Database.Migrate();

                Seeder.SeedAll(context);
            }


            builder.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
            return builder;
        }
    }

}
