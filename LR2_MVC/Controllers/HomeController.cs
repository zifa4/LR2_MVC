using LR2_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LR2_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TaskFirst()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TaskFirst(string a, string b, string c)
        {
            if (double.TryParse(a, out double n1) && double.TryParse(b, out double n2) && double.TryParse(c, out double n3))
            {
                if (n1 >= 0 && n2 >= 0 && n3 >= 0)
                {
                    ViewBag.Result = (n1 + n2 + n3) / 3;
                }
                else ViewBag.Result = n1 * n2 * n3;

                return View();
            }
            else
            {
                ViewBag.E = "Введите числа, попробуйте еще раз";
                return View();
            }
        }
        public IActionResult TaskSecond()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TaskSecond(string a)
        {
            if (int.TryParse(a, out int n1))
            {
                if (n1 % 2 != 0 && n1 >= 100 && n1 < 1000)
                {
                    @ViewBag.Result = "Правда";
                }
                else @ViewBag.Result = "Ложь";
                return View();
            }
            else
            {
                ViewBag.E = "Введите числа, попробуйте еще раз";
                return View();
            }
        }

        public IActionResult TaskThird()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TaskThird(string a)
        {

            if (a[0] == a[a.Length - 1])
            {
                ViewBag.Result = $"Да. Слово <{a}> начинается и заканчивается на одну и ту же букву";
            }
            else
            {
                ViewBag.Result = $"Нет. Слово <{a}> начинается и заканчивается не на одну и ту же букву";
            }
            return View();
        }
    }
}