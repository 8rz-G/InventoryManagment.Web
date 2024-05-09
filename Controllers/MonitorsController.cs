using InventoryManagment.Web.Data;
using InventoryManagment.Web.Models.Entities;
using InventoryManagment.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.Web.Controllers
{
	public class MonitorsController : Controller
	{
		private ApplicationDbContext _context;
		public MonitorsController(ApplicationDbContext context)
		{
			this._context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			// returning list of laptops from database to Index view
			var laptops = await _context.Monitors.ToListAsync();

			return View(laptops);
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
			var monitor = await _context.Monitors.FindAsync(Id);

			ViewBag.Users = new SelectList(_context.Users.ToList(), "Id", "Name");
			ViewBag.Producers = new SelectList(_context.Producers.ToList(), "Id", "Name");

			return View(monitor);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(Laptop viewModel)
		{
			// searching for laptop in database to update values
			var monitor = await _context.Laptops.FindAsync(viewModel.Id);

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
			var monitor = await _context.Monitors.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == viewModel.Id);

			// removing monitor from database
			if (monitor is not null)
			{
				_context.Monitors.Remove(monitor);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction("Index");
		}
	}
}
