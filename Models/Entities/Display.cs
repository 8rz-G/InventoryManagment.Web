using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagment.Web.Models.Entities
{
	public class Display
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
