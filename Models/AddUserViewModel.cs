namespace InventoryManagment.Web.Models
{
	public class AddUserViewModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public int Department { get; set; }
		public DateOnly DateOfEmployment { get; set; }
	}
}
