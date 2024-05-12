using InventoryManagment.Web.Models.Entities;
using InventoryManagment.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagment.Web.Data;

namespace InventoryManagment.Web.Controllers
{
	public class LaptopModelsController : Controller
	{
		private ApplicationDbContext _context;
		public LaptopModelsController(ApplicationDbContext context)
		{
			this._context = context;
		}
		public async Task<IActionResult> Index()
		{
			var laptopM = await _context.LaptopModels.ToListAsync();
			return View(laptopM);
		}
		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Producers = new SelectList(_context.Producers.ToList(), "Id", "Name");

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddLaptopModelViewModel viewModel)
		{
			var laptopModel = new LaptopModel
			{
				Name = viewModel.Name,
				Producer = viewModel.Producer
			};

			await _context.AddAsync(laptopModel);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Edit(int Id)
		{
			var laptopM = await _context.Laptops.FindAsync(Id);

			ViewBag.Producers = new SelectList(_context.Producers.ToList(), "Id", "Name");

			return View(laptopM);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(LaptopModel viewModel)
		{
			// searching for elements of database to update values
			var laptopM = await _context.LaptopModels.FindAsync(viewModel.Id);

			// updating database values
			if (laptopM is not null)
			{
				laptopM.Id = viewModel.Id;
				laptopM.Name = viewModel.Name;
				laptopM.Producer = viewModel.Producer;
			}

			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(Laptop viewModel)
		{
			// finding laptop to remove
			var laptopM = await _context.LaptopModels.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == viewModel.Id);
			// removing laptop from database
			if (laptopM is not null)
			{
				_context.LaptopModels.Remove(laptopM);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction("Index");
		}

	}
}
