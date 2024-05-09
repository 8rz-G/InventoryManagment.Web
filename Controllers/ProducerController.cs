using Microsoft.AspNetCore.Mvc;

namespace InventoryManagment.Web.Controllers
{
	public class ProducerController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
