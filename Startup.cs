using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Interfaces;
using SmartSchool.WebAPI.Repositories;

namespace SmartSchool.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // acessa o appsettings.json
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // config database
            services.AddDbContext<SmartContext>(
                context => context.UseSqlite(
                    Configuration.GetConnectionString("Default")
                )
            );

            // dependency inversion
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            

            services.AddControllers()
                .AddNewtonsoftJson(option // prevent loops
                    => option.SerializerSettings.ReferenceLoopHandling
                    = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}