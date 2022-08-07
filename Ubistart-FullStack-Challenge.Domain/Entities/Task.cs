using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ubistart_FullStack_Challenge.Domain.Entities
{
	public class Task
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdTask { get; set; }
		public DateTime InsertionDate { get; set; }
		public string Description { get; set; }
		public DateTime Deadline { get; set; }
		public DateTime FinishDate { get; set; }
		public DateTime EditDate { get; set; }
		[ForeignKey("UserFK")]
		public User User { get; set; }
		public int UserFK { get; set; }
	}
}
