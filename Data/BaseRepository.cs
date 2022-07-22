using BrianTech008Api.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BrianTech008Api.Data
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
   // public class BaseRepository
    {
        private readonly DataContext dc;
        private BaseRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public IQueryable<T> FindAll()
        {
            return this.dc.Set<T>()
                .AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.dc.Set<T>()
                .Where(expression)
                .AsNoTracking();
        }
    }
}
