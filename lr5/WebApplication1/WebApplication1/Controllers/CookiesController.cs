using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CookiesController : Controller
    {
        public IActionResult Check(string id)
       {
            if (string.IsNullOrEmpty(id))
            {
                return Content("Cookie key is null or empty.");
            }

            if (Request.Cookies.ContainsKey(id))
            {
                var value = Request.Cookies[id];
                return Content($"Cookie with key '{id}' exists, and its value is '{value}'.");
            }
            else
            {
                return Content($"Cookie with key '{id}' does not exist.");
            }
        }
    }
}