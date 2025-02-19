using System.Diagnostics;
using CodeRabbitDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeRabbitDemo.Controllers
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
        public IActionResult NonError()
        {
            return View(new List<DemoObject> { new DemoObject
            {
                Name="test",
            } ,new DemoObject{
              Name="hello",} });
        }
        public IActionResult ErrorList()
        {
            var list = new List<DemoObject> { new DemoObject
            {
                Name="test",
            } };
            list.Add(null);

            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
            return View(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 
    }

    class DemoObject
    {
        public string Name { get; set; }
    }
}
