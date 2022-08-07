using System;
using Ubistart_FullStack_Challenge.Domain.Entities;

namespace Ubistart_FullStack_Challenge.Domain.Dtos
{
	public class TaskDto
	{
		public int IdTask { get; set; }
		public DateTime InsertionDate { get; set; }
		public string Description { get; set; }
		public DateTime Deadline { get; set; }
		public DateTime FinishDate { get; set; }
		public DateTime EditDate { get; set; }
		public User User { get; set; }
		public int UserFK { get; set; }
		public TaskDto(DateTime insertionDate, string description, DateTime deadline, User user, int userFK)
		{
			InsertionDate = insertionDate;
			Description = description;
			Deadline = deadline;
			User = user;
			UserFK = userFK;
		}
	}
}
