using System.ComponentModel.DataAnnotations;

namespace InventoryManagment.Web.Models.Entities
{
	public class Department
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
