using Microsoft.AspNetCore.Mvc;
using ozal.business.Abstract;
using ozal.data.Abstract;
using ozal.webui.Models;
using ozal.webui.ViewModels;
using System.Diagnostics;

namespace ozal.webui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductService _productService; //injection
        private ICareService _careService; //injection
        private IRepairService _repairService; //injection
        public HomeController(ILogger<HomeController> logger, IProductService productService, ICareService careService, IRepairService repairService)
        {
            _logger = logger;
            this._productService = productService;
            this._careService = careService;
            this._repairService = repairService;
        }

        public IActionResult Index()
        {
            var proHome = _productService.GetHomeItems();
            var careHome = _careService.GetHomeItems();

            ProCareHome temp = new()
            {
                HomeCares = careHome,
                HomeProducts = proHome
            };
            return View(temp);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CheckRepair(string q)
        {
            if (q == null)
            {
               return NotFound();
            }
            int n = 0;
            try
            {
                n = Convert.ToInt32(q);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
            
            var ret = _repairService.GetIdOfChecked(n);

            if (ret == null)
            {
                return NotFound();
            }

            return View(ret);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}