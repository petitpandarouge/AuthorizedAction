using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestWebApp.Actions;
using Pandatheque.AuthorizedAction.Extensions.DependencyInjection;
using TestWebApp.Policies;
using TestWebApp.Policies.Context;

namespace TestWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Utilisateur
            services.AddPolicy<IIsAdmin, IsAdmin>();
            services.AddPolicy<IIsModification, IsModification>();

            // Enquete
            services.AddPolicy<IIsNotCloture, IsNotCloture>();
            services.AddPolicy<IIsApresOuverture, IsApresOuverture>();
            services.AddPolicy<IIsAvantFermeture, IsAvantFermeture>();

            // Cloturer enquete
            services.AddAuthorizedAction<CloturerEnquetePolicyContext, ICloturerEnquete>()
                    .CheckPolicy<IIsAdmin>()
                    .CheckPolicy<IIsNotCloture>()
                    .CheckPolicy<IIsApresOuverture>()
                    .CheckPolicy<IIsAvantFermeture>()
                    .ThenExecute<CloturerEnqueteAdmin>()
                    .CheckPolicy<IIsModification>()
                    .ThenExecute<CloturerEnqueteModification>();


            services.AddControllersWithViews();
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
            }
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
