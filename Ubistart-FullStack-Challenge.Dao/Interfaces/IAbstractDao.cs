using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ubistart_FullStack_Challenge.Dao.Interfaces
{
	public interface IAbstractDao<TEntity> : IDisposable where TEntity : class
	{
		TEntity Find(params object[] Keys);

		TEntity Find(Expression<Func<TEntity, bool>> where);

		TEntity Find(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, object> includes);
	}
}
