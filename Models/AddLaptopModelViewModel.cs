using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagment.Web.Models
{
	public class AddLaptopModelViewModel
	{
		public string Name { get; set; }
		public int Producer { get; set; }
	}
}
