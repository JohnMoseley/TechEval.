using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heuristics.TechEval.Core.Models {


	
	public class Member {

		public int Id { get; set; }

		[Required]
		[Index("Name", IsUnique = true)]
		[StringLength(50, ErrorMessage = "Name Length can not be greater then 50")]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

        public int? CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }


    }
}


