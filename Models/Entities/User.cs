using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Web.Models.Entities
{
	public class User
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DateOnly DateOfEmployment { get; set; }
	}
}
