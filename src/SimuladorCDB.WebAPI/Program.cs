using SimuladorCDB.Application;
using SimuladorCDB.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
builder.Services.AddApplicationService();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

var profilesTypes = new List<Type>() {
                typeof(ApplicationMapperProfile)
            };

builder.Services.AddAutoMapper(profilesTypes.ToArray());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("LiberaGeral");
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
