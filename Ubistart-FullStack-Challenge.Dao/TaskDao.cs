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
	}
}
