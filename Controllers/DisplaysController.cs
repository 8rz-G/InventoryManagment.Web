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
			var Displays = await _context.Displays.ToListAsync();

			return View(Displays);
		}
		[HttpGet]
		public IActionResult Add()
		{
			// creating ViewBag for user and producers selection dropdown
			ViewBag.Users = new SelectList(_context.Users.ToList(), "Id", "Name");
			ViewBag.Producers = new SelectList(_context.Producers.ToList(), "Id", "Name");

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddDisplayViewModel viewModel)
		{
			// adding user provided data to object for database insertion
			var monitor = new Display
			{
				AssignedTo = viewModel.AssignedTo,
				Producer = viewModel.Producer,
				Model = viewModel.Model,
				InStock = viewModel.InStock,
				SerialNumber = viewModel.SerialNumber
			};

			await _context.AddAsync(monitor);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Edit(int Id)
		{
			var monitor = await _context.Displays.FindAsync(Id);

			ViewBag.Users = new SelectList(_context.Users.ToList(), "Id", "Name");
			ViewBag.Producers = new SelectList(_context.Producers.ToList(), "Id", "Name");

			return View(monitor);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(Display viewModel)
		{
			// searching for Displays in database to update values
			var monitor = await _context.Displays.FindAsync(viewModel.Id);

			// updating database values
			if (monitor is not null)
			{
				monitor.Id = viewModel.Id;
				monitor.AssignedTo = viewModel.AssignedTo;
				monitor.Producer = viewModel.Producer;
				monitor.Model = viewModel.Model;
				monitor.InStock = viewModel.InStock;
				monitor.SerialNumber = viewModel.SerialNumber;
			}

			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(Display viewModel)
		{
			// finding monitor to remove
			var monitor = await _context.Displays.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == viewModel.Id);

			// removing monitor from database
			if (monitor is not null)
			{
				_context.Displays.Remove(monitor);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction("Index");
		}
	}
}
