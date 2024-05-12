using InventoryManagment.Web.Models.Entities;
using InventoryManagment.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagment.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagment.Web.Controllers
{
	public class ProducersController : Controller
	{
		private ApplicationDbContext _context;
		public ProducersController(ApplicationDbContext context)
		{
			this._context = context;
		}
		public IActionResult Index()
		{
			var producers = _context.Producers.ToList();
			return View(producers);
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddLaptopModelViewModel viewModel)
		{
			var producer = new Producer
			{
				Name = viewModel.Name
			};

			await _context.AddAsync(producer);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Edit(int Id)
		{
			var laptop = await _context.Laptops.FindAsync(Id);

			ViewBag.Users = new SelectList(_context.Users.ToList(), "Id", "Name");
			ViewBag.Producers = new SelectList(_context.Producers.ToList(), "Id", "Name");

			return View(laptop);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(Producer viewModel)
		{
			// searching for elements of database to update values
			var producer = await _context.Producers.FindAsync(viewModel.Id);

			// updating database values
			if (producer is not null)
			{
				producer.Id = viewModel.Id;
				producer.Name = viewModel.Name;
			}

			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
	}
}
