using InventoryManagment.Web.Data;
using InventoryManagment.Web.Models;
using InventoryManagment.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.Web.Controllers
{
	public class LaptopsController : Controller
	{
		private ApplicationDbContext _context;
		public LaptopsController(ApplicationDbContext context)
		{
			this._context = context;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var users = await _context.Laptops.ToListAsync();

			return View(users);
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddLaptopViewModel viewModel)
		{
			var laptop = new Laptop
			{
				AssignedTo = viewModel.AssignedTo,
				Producer = viewModel.Producer,
				Model = viewModel.Model,
				InStock = viewModel.InStock,
				SerialNumber = viewModel.SerialNumber
			};

			await _context.AddAsync(laptop);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Edit()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Edit(Laptop viewModel)
		{
			var laptop = await _context.Laptops.FindAsync(viewModel.Id); 

			if (laptop is not null)
			{
				laptop.Id = viewModel.Id;
				laptop.AssignedTo = viewModel.AssignedTo;
				laptop.Producer = viewModel.Producer;
				laptop.Model = viewModel.Model;
				laptop.InStock = viewModel.InStock;
				laptop.SerialNumber = viewModel.SerialNumber;
			}
			
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(Laptop viewModel)
		{
			var laptop = await _context.Laptops.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == viewModel.Id);
			
			if (laptop is not null)
			{
				_context.Laptops.Remove(laptop);
				await _context.SaveChangesAsync();
			}
			
			return View();
		}

	}
}
