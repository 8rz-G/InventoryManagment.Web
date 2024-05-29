using InventoryManagment.Web.Data;
using InventoryManagment.Web.Models.Entities;
using InventoryManagment.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.Web.Controllers
{
	public class DisplaysController : Controller
	{
		private ApplicationDbContext _context;
		public DisplaysController(ApplicationDbContext context)
		{
			this._context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			// returning list of Displays from database to Index view
			var Displays = await _context.Monitors.ToListAsync();

			return View(Displays);
		}
		[HttpGet]
		public IActionResult Add()
		{
			// creating ViewBag for user and producers selection dropdown

			ViewBag.Users = new SelectList(_context.Users.ToList(), "Id", "Name");
			ViewBag.Producers = new SelectList(_context.Producers.ToList(), "Id", "Name");
			ViewBag.hardwareModels = new SelectList(_context.HardwareModels
				.Where(x => x.Category == "Monitor").Select(x => new { x.Id, x.Name })
				.Select(x => new { x.Id, x.Name })
				.ToList(), "Id", "Name");

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddDisplayViewModel viewModel)
		{
			// adding user provided data to object for database insertion

			var display = new Display
			{
				AssignedTo = viewModel.AssignedTo,
				Producer = viewModel.Producer,
				HardwareModel = viewModel.HardwareModel,
				InStock = viewModel.InStock,
				SerialNumber = viewModel.SerialNumber,
				DateOfPurchase = viewModel.DateOfPurchase
			};

			await _context.AddAsync(display);
			await _context.SaveChangesAsync();

			return RedirectToAction("DisplayChange", "InventoryChanges", display.Id);
		}
		[HttpGet]
		public async Task<IActionResult> Edit(int Id)
		{
			var display = await _context.Monitors.FindAsync(Id);

			ViewBag.Users = new SelectList(_context.Users.ToList(), "Id", "Name");
			ViewBag.Producers = new SelectList(_context.Producers.ToList(), "Id", "Name");
			ViewBag.hardwareModels = new SelectList(_context.HardwareModels
				.Where(x => x.Category == "Monitor").Select(x => new { x.Id, x.Name }).ToList(), "Id", "Name");

			return View(display);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(Display viewModel)
		{
			// searching for display in database
			var display = await _context.Monitors.FindAsync(viewModel.Id);

			// updating database values
			if (display is not null)
			{
				display.Id = viewModel.Id;
				display.AssignedTo = viewModel.AssignedTo;
				display.Producer = viewModel.Producer;
				display.HardwareModel = viewModel.HardwareModel;
				display.InStock = viewModel.InStock;
				display.SerialNumber = viewModel.SerialNumber;
				display.DateOfPurchase = viewModel.DateOfPurchase;
			}

			await _context.SaveChangesAsync();

			return RedirectToAction("DisplayChange", "InventoryChanges", new { id = viewModel.Id });
		}
		[HttpPost]
		public async Task<IActionResult> Delete(Display viewModel)
		{
			// finding display to remove
			var display = await _context.Monitors.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == viewModel.Id);

			// removing display from database
			if (display is not null)
			{
				_context.Monitors.Remove(display);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction("Index");
		}
	}
}
