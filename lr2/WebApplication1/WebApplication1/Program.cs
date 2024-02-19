using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CalcService>();
builder.Services.AddTransient<TimeOfDayService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();