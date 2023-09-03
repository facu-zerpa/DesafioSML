using DesafioSML.Data;
using DesafioSML.Repository;
using DesafioSML.Repository.IRepository;
using DesafioSML.Services;
using DesafioSML.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace DesafioSML
{
    public class StartUp
    {
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<CustomerIRepository, CustomerRepository>();
            services.AddScoped<InvoiceIRepository, InvoiceRepository>();
            services.AddScoped<InvoiceItemIRepository, InvoiceItemRepository>();

            services.AddScoped<CustomerIService, CustomerService>();
            services.AddScoped<InvoiceIService, InvoiceService>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddAutoMapper(typeof(StartUp));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("corsapp");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
