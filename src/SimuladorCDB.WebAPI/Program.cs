using FluentValidation;
using SimuladorCDB.WebAPI.Models.CalcularCDB;

namespace SimuladorCDB.WebAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dependency Injection
            builder.Services.AddApplicationService();
            builder.Services.AddTransient<IValidator<CalcularCdbRequest>, CalcularCdbRequestValidator>();
            
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(WebApiMapperProfile));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "LiberaGeral",
                builder =>
                {
                        builder.WithOrigins("*")
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("LiberaGeral");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}