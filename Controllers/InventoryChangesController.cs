using InventoryManagment.Web.Data;
using InventoryManagment.Web.Models;
using InventoryManagment.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Linq;


namespace InventoryManagment.Web.Controllers
{
	public class InventoryChangesController : Controller
	{
		private ApplicationDbContext _context;
		public InventoryChangesController(ApplicationDbContext context)
		{
			this._context = context;
		}
		public async Task<IActionResult> LaptopHistory(int Id) 
		{ 
			var inventoryChanges = await _context.InventoryChanges
				.Where(x => x.HardwareId == Id && x.TypeOfHardware == "Laptop")
				.ToListAsync();

			return View(inventoryChanges);
		}
		public async Task<IActionResult> DisplayHistory(int Id) 
		{ 
			var inventoryChanges = await _context.InventoryChanges
				.Where(x => x.HardwareId == Id && x.TypeOfHardware == "Monitor")
				.ToListAsync();

			return View(inventoryChanges);
		}
		public async Task<IActionResult> DisplayChange(int Id)
		{
			var display = await _context.Monitors.FindAsync(Id);
			return RedirectToAction("AddDisplayChange", display);
		}
		public async Task<IActionResult> AddDisplayChange(Display change)
		{
			var inventoryChange = new InventoryChange
			{ 
				HardwareId = change.Id,
				InStock = change.InStock,
				SerialNumber = change.SerialNumber,
				HardwareModelName = _context.HardwareModels
				.Where(x => x.Id == change.HardwareModel).Select(x => x.Name ).SingleOrDefault(),
				AssignedTo = change.AssignedTo,
				Producer = change.Producer,
				HardwareModel = change.HardwareModel,
				TypeOfHardware = "Monitor",
				DateOfChange = DateTime.Now
		};

			await _context.AddAsync(inventoryChange);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Displays");
		}
		public async Task<IActionResult> LaptopChange(int Id)
		{
			var laptop = await _context.Laptops.FindAsync(Id);
			return RedirectToAction("AddLaptopChange", laptop);
		}
		public async Task<IActionResult> AddLaptopChange(Laptop change)
		{
			var inventoryChange = new InventoryChange
			{ 
				HardwareId = change.Id,
				InStock = change.InStock,
				SerialNumber = change.SerialNumber,
				HardwareModelName = _context.HardwareModels
				.Where(x => x.Id == change.HardwareModel).Select(x => x.Name ).SingleOrDefault(),
				AssignedTo = change.AssignedTo,
				Producer = change.Producer,
				HardwareModel = change.HardwareModel,
				TypeOfHardware = "Laptop",
				DateOfChange = DateTime.Now
		};

			await _context.AddAsync(inventoryChange);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Laptops");
		}
	}
}