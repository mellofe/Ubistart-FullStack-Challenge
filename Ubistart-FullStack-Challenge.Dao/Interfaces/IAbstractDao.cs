using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ubistart_FullStack_Challenge.Dao.Interfaces
{
	public interface IAbstractDao<TEntity> : IDisposable where TEntity : class
	{
		public TEntity Find(Expression<Func<TEntity, bool>> where);
		public TEntity Create(TEntity User);
	}
}
