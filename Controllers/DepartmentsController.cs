using InventoryManagment.Web.Data;
using InventoryManagment.Web.Models;
using InventoryManagment.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.Web.Controllers
{
	public class DepartmentsController : Controller
	{
		private ApplicationDbContext _context;
		public DepartmentsController(ApplicationDbContext context)
		{
			this._context = context;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var department = await _context.Departments.ToListAsync();

			return View(department);
		}
		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddDepartmentViewModel viewModel)
		{
			var department = new Department { Name = viewModel.Name };

			await _context.AddAsync(department);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var department = await _context.Departments.FindAsync(id);

			return View(department);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Department viewModel)
		{
			var department = await _context.Departments.FindAsync(viewModel.Id);
			
			if (department is not null)
			{ 
				department.Name = viewModel.Name; 
			}
			
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<ActionResult> Delete(Department viewModel)
		{
			var department = await _context.Departments.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == viewModel.Id);

			if (department is not null)
			{
				_context.Departments.Remove(department);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction("Index");
		}
	}
}
