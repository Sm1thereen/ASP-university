using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile(@"./books.json").AddJsonFile(@"./profiles.json");
var app = builder.Build();

app.Map("/Library", async (context) => 
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync("<div style=\"font-family: Arial, sans-serif; text-align: center;\"> <h1 style=\"color:black;\">Welcome to the Library!</h1> </div>");
});

app.Map("/Library/Books", async (HttpContext context, IConfiguration appConfig) => 
{
    context.Response.ContentType = "text/html; charset=utf-8";
    StringBuilder sb = new StringBuilder("<div style=\"font-family: Arial, sans-serif; text-align: center;\"> <h2 style=\"color:black;\">Books in the Library:</h2> <ul style=\"list-style-type:none;\">");
    for (int i = 0; i < 5; i++)
    {
        IConfigurationSection book = appConfig.GetSection($"books:{i}");
        sb.Append($"<li style=\"color:black;font-size:16px;margin-bottom:10px;\"> <b>{book["title"]}</b> | {book["author"]} | {book["genre"]} | {book["year"]}</li>");
    }
    sb.Append("</ul> </div>");
    await context.Response.WriteAsync($"{sb.ToString()}");
});

app.Map("/Library/Profile/{id:int}", async (HttpContext context, IConfiguration appConfig, int id) => 
{
    context.Response.ContentType = "text/html; charset=utf-8";
    StringBuilder sb = new StringBuilder($"<div style=\"font-family: Arial, sans-serif; text-align: center;\"> <h2 style=\"color:b;blue;\">User profile with id number {id}</h2>");
    IConfiguration user = appConfig.GetSection($"profiles:{id}");
    sb.Append($"<div style=\"color:blue;font-size:16px;margin-bottom:10px;\"> <b>Id:</b> {user["id"]}</div>");
    sb.Append($"<div style=\"color:blue;font-size:16px;margin-bottom:10px;\"> <b>Name:</b> {user["name"]}</div>");
    sb.Append($"<div style=\"color:blue;font-size:16px;margin-bottom:10px;\"> <b>Age:</b> {user["age"]} years old</div> </div>");
    await context.Response.WriteAsync($"{sb.ToString()}");
});

app.Map("/Library/Profile/", async (HttpContext context, IConfiguration appConfig) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync("<div style=\"font-family: Arial, sans-serif; text-align: center;\"> <h2 style=\"color:blue;\">Information about current user</h2>" +
        "<div style=\"color:black;font-size:16px;margin-bottom:10px;\"> <b>Name:</b> Klishevych Ivan</div>" +
        "<div style=\"color:black;font-size:16px;margin-bottom:10px;\"> <b>20 years old</div> </div>");
});

app.Run();
g