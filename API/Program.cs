using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});





builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();
app.UseCors("AllowReactApp");
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();