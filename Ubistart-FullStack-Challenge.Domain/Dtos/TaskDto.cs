﻿using System;
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
		public TaskDto(DateTime insertionDate, string description, DateTime deadline)
		{
			InsertionDate = insertionDate;
			Description = description;
			Deadline = deadline;
		}
		public TaskDto(Task task)
		{
			IdTask = task.IdTask;
			InsertionDate = task.InsertionDate;
			Description = task.Description;
			Deadline = task.Deadline;
			FinishDate = task.FinishDate;
			EditDate = task.EditDate;
		}
	}
}
