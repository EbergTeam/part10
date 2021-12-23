using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string login, string password, int age, string comment, bool isMarried, string color, string phone)
        {
            string authInfo = $"Login: {login}, password: {password}, age: {age}, comment {comment}, isMarried {isMarried}, {color} {phone}";
            return Content(authInfo);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Inject()
        {
            return View();
        }
        public IActionResult SendToView()
        {
            ViewData["Message"] = "Вывод из ViewData"; // ViewData представляет словарь из пар ключ-значение
            ViewBag.String = "Вывод из ViewBag";
            ViewBag.List = new List<string> { "Россия", "США" }; // ViewBag подобен ViewData. Он позволяет определить различные свойства
                                                                 // присвоить им любое значение. И не важно, что изначально объект ViewBag
                                                                 // не содержит никакого свойства List, оно определяется динамически
            List<string> players = new List<string> { "Харти", "Юкола" }; // модель представления - для передачи данных  используется одна
                                                                          // из версий метода View
            return View(players);
        }

        public IActionResult Privacy()
        {
            return View();
            //return View("Index"); // можно вызвать другое представление по имени (если находится в той же папке Home)
            //return View("~/Views/Other/Index.cshtml"); // можно вызвать другое представление по полному пути
        }

        public IActionResult RazorInfo()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
