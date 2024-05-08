using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Web.Models.Entities
{
	public class Laptop
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Id")]
		public string AssignedTo { get; set; }
		public string Producer { get; set; }
		public string Model { get; set; }
		public bool InStock { get; set; }
		public string SerialNumber { get; set; }
	}
}
