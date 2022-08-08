using System.Collections.Generic;
using Ubistart_FullStack_Challenge.Domain.Entities;

namespace Ubistart_FullStack_Challenge.Dao.Interfaces
{
	public interface ITaskDao : IAbstractDao<Task>
	{
		public IEnumerable<Task> GetUserTasks(int userFk);
	}
}
