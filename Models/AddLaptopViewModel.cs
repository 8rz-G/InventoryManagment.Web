namespace InventoryManagment.Web.Models
{
	public class AddLaptopViewModel
	{
		public Guid AssignedTo { get; set; }
		public string Producer { get; set; }
		public string Model { get; set; }
		public bool InStock { get; set; }
		public string SerialNumber { get; set; }
	}
}
