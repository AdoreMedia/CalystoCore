using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace Calysto.EntityFrameworkCore
{
	public abstract class EFCoreEntityBase<TEntity> where TEntity : class
	{
		DbContext _context;

		protected EFCoreEntityBase() { }

		protected EFCoreEntityBase(DbContext context)
		{
			_context = context;
		}

		public DbContext GetContext() => _context;

		public EntityEntry<TEntity> GetEntry() => this.GetContext().Entry((TEntity)(object)this);

		/// <summary>
		/// Get navigation property value. Load from database if not already loaded.
		/// </summary>
		/// <typeparam name="TElement"></typeparam>
		/// <param name="expression"></param>
		/// <returns></returns>
		public TElement GetNavigation<TElement>(Expression<Func<TEntity, TElement>> expression) where TElement : EFCoreEntityBase<TElement>
		{
			var fn1 = expression.Compile();
			var fn2 = new Func<EFCoreEntityBase<TEntity>, TElement>(ent1 => fn1.Invoke((TEntity)(object)ent1));

			TElement val1 = fn2.Invoke(this);
			if (val1 != null)
				return val1;
			
			this.GetEntry().Reference(expression).Load();
			return fn2.Invoke(this);
		}

		/// <summary>
		/// Get navigation property value. Load from database if not already loaded.
		/// </summary>
		/// <typeparam name="TElement"></typeparam>
		/// <param name="expression"></param>
		/// <returns></returns>
		public List<TElement> GetNavigation<TElement>(Expression<Func<TEntity, IEnumerable<TElement>>> expression) where TElement : EFCoreEntityBase<TElement>
		{
			var fn1 = expression.Compile();
			var fn2 = new Func<EFCoreEntityBase<TEntity>, List<TElement>>(ent1 => fn1.Invoke((TEntity)(object)ent1) as List<TElement>);

			List<TElement> val1 = fn2.Invoke(this);
			if (val1 != null && val1.Any())
				return val1;

			this.GetEntry().Collection(expression).Load();
			return fn2.Invoke(this);
		}

		private void EnsureAttachedToContext()
		{
			var cx1 = this.GetContext();
			if (cx1 == null)
				throw new ArgumentNullException(nameof(_context));

			EntityState state = cx1.Entry(this).State;

			if (state == EntityState.Detached)
			{
				this.GetContext().Add(this);
			}
			else if (state == EntityState.Added || state == EntityState.Modified || state == EntityState.Unchanged)
			{
				// ok
			}
			else if (state == EntityState.Deleted)
			{
				// already deleted from db, we have to create clone and save it
				throw new Exception("Can not attach deleted or dead entity");
			}
		}

		public virtual int SaveToDB()
		{
			this.EnsureAttachedToContext();
			return this.GetContext().SaveChanges();
		}

		public virtual int DeleteFromDB()
		{
			this.GetContext().Remove(this);
			return this.GetContext().SaveChanges();
		}

		public virtual void ReloadFromDB()
		{
			this.GetContext().Entry(this).Reload();
		}
	}
}
