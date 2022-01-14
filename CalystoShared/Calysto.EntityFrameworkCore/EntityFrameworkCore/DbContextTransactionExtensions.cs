using Calysto.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data.Common;
using System.Reflection;

namespace Calysto.EntityFrameworkCore
{
	public static class DbContextTransactionExtensions
	{
		public static DbTransaction GetDbTransaction(this IDbContextTransaction transaction)
		{
			// EF 5:
			if (transaction is Microsoft.EntityFrameworkCore.Infrastructure.IInfrastructure<DbTransaction> trans)
				return trans.Instance;

			// optional, just as example. Field is private readonly in base class, so we have to use it's owning type
			FieldInfo fi = typeof(RelationalTransaction).GetField("_dbTransaction", BindingFlags.Instance | BindingFlags.NonPublic);
			if (fi?.GetValue(transaction) is DbTransaction trans2)
				return trans2;

			// EF 3.1
			if (CalystoDataBinder.Private.TryGetValue<DbTransaction>(transaction, "_dbTransaction", out var result1))
				return result1;

			if (CalystoDataBinder.Private.TryGetValue<DbTransaction>(transaction, "DbTransaction", out result1))
				return result1;

			throw new NotSupportedException();
		}
	}
}
