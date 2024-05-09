namespace InventoryManagment.Web.Models
{
	public class AddDisplayViewModel
	{
		public Guid AssignedTo { get; set; }
		public int Producer { get; set; }
		public string Model { get; set; }
		public bool InStock { get; set; }
		public string SerialNumber { get; set; }
	}
}
