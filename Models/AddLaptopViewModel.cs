namespace InventoryManagment.Web.Models
{
	public class AddLaptopViewModel
	{
		public Guid AssignedTo { get; set; }
		public int Producer { get; set; }
		public int Model { get; set; }
		public bool InStock { get; set; }
		public string SerialNumber { get; set; }
		public DateOnly DateOfPurchase { get; set; }
	}
}
