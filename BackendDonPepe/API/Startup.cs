using CEN.HELPERS;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }   
        public Startup(IConfiguration configuration) 
        {   
            this.Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddOptions(); 
            services.AddSingleton<IConfiguration>(this.Configuration);
            services.AddControllers();
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("V1", new OpenApiInfo { Title = "Bodega Don Pepe", Version = "V1"});
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/V1/swagger.json", "Bodega Don Pepe V1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(
                options => options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.Development.json")
                .AddEnvironmentVariables()
                .Build();

            Constants.Server_name = this.Configuration.GetValue<String>("SQL:Server_name");
            Constants.Database_name = this.Configuration.GetValue<String>("SQL:Database_name");
            Constants.User_name = this.Configuration.GetValue<String>("SQL:User_name");
            Constants.User_pass = this.Configuration.GetValue<String>("SQL:User_pass");
            Constants.Cadena_conexion = $"data source = {Constants.Server_name}; initial catalog = {Constants.Database_name}; " +
                            $"user id = {Constants.User_name}; password = {Constants.User_pass}; TrustServerCertificate=True";
        }
    }
}
