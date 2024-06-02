using InventoryManagment.Web.Data;
using InventoryManagment.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventoryManagment.Web.Controllers
{
	public class HomeController : Controller
	{
		private ApplicationDbContext _context;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
			this._context = context;
			_logger = logger;
		}

		public IActionResult Index()
		{
			var changes = _context.InventoryChanges.ToList();
			return View(changes);
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
