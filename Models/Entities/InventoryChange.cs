using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagment.Web.Models.Entities
{
	public class InventoryChange
	{
		[Key]
		public int Id { get; set; }
		public int HardwareId { get; set; }
		public bool InStock { get; set; }
		public string SerialNumber {  get; set; }
		public string HardwareModelName { get; set; }
		public Guid AssignedTo { get; set; }
		[ForeignKey("Id")]
		public int Producer {  get; set; }
		[ForeignKey("Id")]
		public int HardwareModel {  get; set; }
		public string TypeOfHardware { get; set; }
		public DateTime DateOfChange { get; set; }
	}
}
