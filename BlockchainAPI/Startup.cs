using Microsoft.EntityFrameworkCore;
using TransactionsAPI.Context;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;
using TransactionsAPI.Services.Mapper;

namespace TransactionsAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                =new DefaultContractResolver());

            services.AddDbContextPool<MySQLDbContext>(options => options.UseMySql(Configuration.GetConnectionString("MySQLDbConnectionString"),
                                                            new MySqlServerVersion(new Version(8, 0, 32))));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TransactionAPI", Version = "v1" });
            });


            services.AddAutoMapper(typeof(Mapper));

            services.AddCors(x => x.AddPolicy(name: "AllowWebApp",
                policy =>
                {
                    policy.WithOrigins("http://localhost:3011").AllowAnyHeader().AllowAnyMethod();
                }));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseResponseCaching();

            app.UseAuthorization();


            app.UseCors("AllowWebApp");
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }

    }
}
