using Microsoft.EntityFrameworkCore;
using Ubistart_FullStack_Challenge.Dao.Interfaces;
using Ubistart_FullStack_Challenge.Data.Context;
using Ubistart_FullStack_Challenge.Domain.Entities;

namespace Ubistart_FullStack_Challenge.Dao
{
	public class UserDao : AbstractDao<User>, IUserDao
	{
		public UserDao(SqlContext context)
			: base(context) { }
	}
}
