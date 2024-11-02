using ECommerce.Domain.Core.SeedWork;
using ECommerce.Infra.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EF.Infra.Core
{
    public abstract class EFRepository<TDbContext, TAggregateRoot> : IRepository<TAggregateRoot>
        where TAggregateRoot : AggregateRoot
        where TDbContext : DbContext
    {
        protected TDbContext db;
        protected DbSet<TAggregateRoot> table;
        protected EFRepository(TDbContext dbContext)
        {
            this.db = dbContext;
            this.table = this.db.Set<TAggregateRoot>();
        }
        public void Add(TAggregateRoot aggregateRoot)
        {
            this.table.Add(aggregateRoot);
        }

        public IEnumerable<TAggregateRoot> Find(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return this.table.Where(expression).AsEnumerable();
        }

        public TAggregateRoot FindById(Guid Id)
        {
            return this.table.Find(Id);
        }

        public void Remove(TAggregateRoot aggregateRoot)
        {
            this.table.Remove(aggregateRoot);
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            this.table.Update(aggregateRoot);
        }

        public void UpdateBulk(TAggregateRoot[] aggregateRoot)
        {
            this.table.UpdateRange(aggregateRoot);
        }
    }
}
