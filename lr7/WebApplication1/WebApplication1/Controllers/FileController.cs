using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace WebApplication1.Controllers
{
    public class FileController : Controller
    {
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            string content = $"Ім'я: {firstName}\nПрізвище: {lastName}";
            byte[] byteArray = Encoding.UTF8.GetBytes(content);

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", $"{fileName}.txt");
            System.IO.File.WriteAllBytes(filePath, byteArray);

            return PhysicalFile(filePath, "text/plain", $"{fileName}.txt");
        }
    }
}