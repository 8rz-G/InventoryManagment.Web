using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagment.Web.Models.Entities
{
	public class DisplayModel
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		[ForeignKey("Id")]
		public int Producer { get; set; }
	}
}
