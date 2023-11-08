using CoopManagementApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CoopManagementApp
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
            // Add Entity Framework DbContext to the services and configure it to use a SQL Server database.
            services.AddDbContext<ManagementDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptions => sqlServerOptions.MigrationsAssembly("CoopManagementApp"));
            });


            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Show detailed error information in the development environment.
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // Handle errors in a user-friendly way in production.
                app.UseHsts(); // Add HSTS (HTTP Strict Transport Security) for enhanced security in production.
            }

            app.UseHttpsRedirection(); // Redirect HTTP to HTTPS.
            app.UseStaticFiles(); // Serve static files like CSS, JavaScript, and images.
            app.UseRouting(); // Enable routing for handling requests.

            app.UseAuthorization(); // Add authorization middleware.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); // Map Razor Pages as endpoints.
            });
        }




    }
}

