using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            string key = form["Key"];
            string value = form["Value"];
            DateTime date = DateTime.Parse(form["Date"]);
                
           
            HttpContext.Response.Cookies.Append(key, value, new CookieOptions
            {
                Expires = DateTime.SpecifyKind(date, DateTimeKind.Utc),
            });

            var message = @"
                <style>
                    body {
                        background-color: #f2f2f2;
                        font-family: Arial, sans-serif;
                    }
                    .container {
                        width: 50%;
                        margin: 0 auto;
                        padding: 20px;
                        border: 2px solid #ccc;
                        border-radius: 5px;
                        background-color: #fff;
                    }
                    h1 {
                        color: #333;
                        text-align: center;
                    }
                    p {
                        color: #666;
                        font-size: 16px;
                    }
                    .cookie-info {
                        margin-top: 20px;
                        padding: 10px;
                        background-color: #dff0d8;
                        border: 1px solid #d6e9c6;
                        border-radius: 5px;
                    }
                    .cookie-info b {
                        color: #3c763d;
                    }
                    a {
                        color: #007bff;
                        text-decoration: none;
                    }
                </style>
                <div class='container'>
                    <h1>Cookie Successfully Added</h1>
                    <div class='cookie-info'>
                        <p>Cookie with the key <b>'" + key + @"'</b> and value of <b>'" + value + @"'</b> was added.</p>
                        <p>Expiration date set at <span style='color: #3c763d;'>" + date + @"</span></p>
                        <p><a href='/Cookies/Check/" + key + @"'>Check if it was properly stored</a></p>
                    </div>
                </div>";

            return Content(message, "text/html; charset=utf-8");
        }
    }
}
