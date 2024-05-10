using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Web.Models.Entities
{
	public class Laptop
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Id")]
		public Guid AssignedTo { get; set; }
		[ForeignKey("Id")]
		public int Producer { get; set; }
		public string Model { get; set; }
		public bool InStock { get; set; }
		public string SerialNumber { get; set; }
	}
}
