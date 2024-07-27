using ProyectoExamen2.Database;
using Microsoft.EntityFrameworkCore;
using ProyectoExamen2.Services.Interfaces;
using ProyectoExamen2.Services;
using ProyectoExamen2.Helpers;

namespace ProyectoExamen2
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // Services
        public void ConfigureService(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<ProyectoExamenContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IClientsService, ClientsService>();
            services.AddTransient<ILoanService, LoanService>();

            //Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        //Middlewords
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
