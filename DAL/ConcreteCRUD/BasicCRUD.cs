using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstractions;
using WebApi_LinkManager.DAL;

namespace DataAccess
{
    public class BasicCRUD<T> : IBasicCRUD<T> where T : class
    {
        public virtual void Add(T entity)
        {
            using (var context = new LinkContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
            } 
        }

        public virtual IQueryable<T> AsQueryable()
        {
            using (var context = new LinkContext())
            {
                return context.Set<T>();
            }
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            using (var context = new LinkContext())
            {
                var entity = context.Set<T>().Single(predicate);
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public virtual void Edit(T entity)
        {
            using (var context = new LinkContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            using (var context = new LinkContext())
            {
                return context.Set<T>().Where(predicate).ToList();
            }  
        }

        public virtual T First(Expression<Func<T, bool>> predicate)
        {
            using (var context = new LinkContext())
            {
                return context.Set<T>().Where(predicate).FirstOrDefault();
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (var context = new LinkContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public virtual T Single(Expression<Func<T, bool>> predicate)
        {
            using (var context = new LinkContext())
            {
                return context.Set<T>().Where(predicate).FirstOrDefault();
            }
        }
    }
}
