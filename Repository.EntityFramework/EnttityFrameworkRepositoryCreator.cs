using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityFramework
{
    public class EntityFrameworkRepositoryCreator : IRepositoryCreator
    {
        public Repository<T> GetRepository<T>()
            where T : class
        {
            //Entity Framework
            var repository = new EFRepository<MyContext, T>(new Func<MyContext, DbSet<T>>(ContextSetSelector<T>));

            //Original way Entity Framework
            //EFRepository<MyContext, Student, int> repository = new EFRepository<MyContext, Student, int>(x => x.Students);

            return repository;
        }

        static DbSet<TValue> ContextSetSelector<TValue>(MyContext context)
            where TValue : class
        {
            /* Could be done with a switch to skip Reflection */
            string className = typeof(TValue).Name;
            object val = context.GetType().GetProperty(className + suffix).GetValue(context);
            return val as DbSet<TValue>;
        }
        static readonly string suffix = "s";
    }
}
