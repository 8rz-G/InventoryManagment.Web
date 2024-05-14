using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Web.Models
{
	public class AddInventoryChangeViewModel
	{
		public int HardwareId { get; set; }
		public bool InStock { get; set; }
		public string SerialNumber { get; set; }
		public string HardwareModelName { get; set; }
		public Guid AssignedTo { get; set; }
		public int Producer { get; set; }
		public int HardwareModel { get; set; }
		public string TypeOfHardware { get; set; }
		public DateOnly DateOfChange { get; set; }
	}
}
