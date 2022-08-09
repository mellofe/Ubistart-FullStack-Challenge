using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using Ubistart_FullStack_Challenge.Dao.Interfaces;
using Ubistart_FullStack_Challenge.Data.Context;
using Ubistart_FullStack_Challenge.Domain.Entities;

namespace Ubistart_FullStack_Challenge.Dao
{
	public class TaskDao : AbstractDao<Task>, ITaskDao
	{
		public TaskDao(SqlContext context)
			: base(context) { }
		public IEnumerable<Task> GetUserTasks(int userFk)
		{
			return Query(x => x.UserFK == userFk);
		}
		public IEnumerable<Task> GetAllTasks()
		{
			return DbSet;
		}
		public bool Update(Task task)
		{
			try
			{
				EntityEntry<Task> entry = NewMethod(task);

				DbSet.Attach(task);

				entry.State = EntityState.Modified;

				return Save() > 0;
			}
			catch (Exception)
			{

				throw;
			}
		}
		private EntityEntry<Task> NewMethod(Task task)
		{
			return context.Entry(task);
		}
	}
}
