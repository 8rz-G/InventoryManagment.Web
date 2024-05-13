using InventoryManagment.Web.Models.Entities;
using InventoryManagment.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagment.Web.Data;

namespace InventoryManagment.Web.Controllers
{
	public class HardwareModelsController : Controller
	{
		private ApplicationDbContext _context;
		public HardwareModelsController(ApplicationDbContext context)
		{
			this._context = context;
		}
		public async Task<IActionResult> Index()
		{
			var hardwareModels = await _context.HardwareModels.ToListAsync();
			return View(hardwareModels);
		}
		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Producers = new SelectList(_context.Producers.ToList(), "Id", "Name");

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddHardwareModelViewModel viewModel)
		{
			var hardwareModelodel = new HardwareModel
			{
				Name = viewModel.Name,
				Producer = viewModel.Producer,
				Category = viewModel.Category
			};

			await _context.AddAsync(hardwareModelodel);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Edit(int Id)
		{
			var hardwareModel = await _context.Laptops.FindAsync(Id);

			ViewBag.Producers = new SelectList(_context.Producers.ToList(), "Id", "Name");

			return View(hardwareModel);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(HardwareModel viewModel)
		{
			// searching for elements of database to update values
			var hardwareModel = await _context.HardwareModels.FindAsync(viewModel.Id);

			// updating database values
			if (hardwareModel is not null)
			{
				hardwareModel.Id = viewModel.Id;
				hardwareModel.Name = viewModel.Name;
				hardwareModel.Producer = viewModel.Producer;
				hardwareModel.Category = viewModel.Category;
			}

			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(HardwareModel viewModel)
		{
			// finding laptop to remove
			var hardwareModel = await _context.HardwareModels.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == viewModel.Id);
			// removing laptop from database
			if (hardwareModel is not null)
			{
				_context.HardwareModels.Remove(hardwareModel);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction("Index");
		}

	}
}
