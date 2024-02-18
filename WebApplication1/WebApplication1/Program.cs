using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Company company = new Company("Apple", "IT", 1976);


var random = new Random();


app.MapGet("/", context =>
{
    var randomNumber = random.Next(101);
    return context.Response.WriteAsync($"Company: {company.Name}, Industry: {company.Industry}, yearFounded: {company.YearFounded}" + " " + $"Random number: {randomNumber}");
});

app.Run();