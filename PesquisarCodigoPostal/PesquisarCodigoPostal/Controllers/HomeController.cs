using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PesquisarCodigoPostal.Data;
using PesquisarCodigoPostal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisarCodigoPostal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PesquisarCodigoPostalContext _context;

        public HomeController(ILogger<HomeController> logger, PesquisarCodigoPostalContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string query)
        {

            
             var search = from s in _context.CodigoPostal
                          where s.CodigoPostalString.Contains(query)
                          select s;


            if (search.ToList().Count>20)
            {
                ViewBag.Message= $"Os resultados para '{query}' foram superiores a 20, por favor refine sua pesquisa.";
                return View();
            }
            else if (search.ToList().Count == 0)
            {
                ViewBag.Message = $"Não foram encontrados resultados para '{query}'.";
                return View();
            }
            else
            {
                ViewBag.Message = $"Foram encontrados {search.ToList().Count} resultados para '{query}'.";
                return View(search.ToList());
            }
            
            
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
    }
}
