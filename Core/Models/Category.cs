using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heuristics.TechEval.Core.Models {

	public class Category {

		public int Id { get; set; }

		[Required]
		[Index("Name", IsUnique = true)]
		[StringLength(50, ErrorMessage = "Name Length can not be greater then 50")]
		public string Name { get; set; }
	}
}


