using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ubistart_FullStack_Challenge.Domain.Dtos;

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
		public Task(TaskDto task, User user, int userFk)
		{
			IdTask = task.IdTask;
			InsertionDate = task.InsertionDate;
			Description = task.Description;
			Deadline = task.Deadline;
			FinishDate = task.FinishDate;
			EditDate = task.EditDate;
			User = user;
			UserFK = userFk;
		}
		public Task() { }
	}
}
