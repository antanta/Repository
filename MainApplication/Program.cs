using Domain;
using Repository.EntityFramework;
using Repository.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Repository;

namespace MainApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository<Student> repository = GetRepository<Student>();

            var s = new Student();
            s.Id = 1;
            s.Name = "antanta";

            repository.Insert(s);
            repository.SaveChanges();

            foreach (var item in repository.Items)
            {
                Console.WriteLine("{0} {1}", item.Id, item.Name);
            }
        }

        static Repository<T> GetRepository<T>()
            where T : class
        {
            //FileStream
            string fileName = typeof(T).Name + suffix;
            Repository<T> repository = new FileSystemRepository<T>(fileName, new Func<T, object>(FileKeySelector<T>));

            //Entity Framework
            //var repository = new EFRepository<MyContext, T>(new Func<MyContext, DbSet<T>>(ContextSetSelector<T>));

            //Original way Entity Framework
            //EFRepository<MyContext, Student, int> repository = new EFRepository<MyContext, Student, int>(x => x.Students);

            return repository;
        }

        static object FileKeySelector<TValue>(TValue entity)
        {
            /* Could be done with a switch to skip Reflection. Also can look for [Key] attribute */
            object val = entity.GetType().GetProperty(fileIdPropName).GetValue(entity);
            return val;
        }
        static readonly string fileIdPropName = "Id";

        static DbSet<TValue> ContextSetSelector<TValue>(MyContext context)
            where TValue: class
        {
            /* Could be done with a switch to skip Reflection */
            string className = typeof(TValue).Name;
            object val = context.GetType().GetProperty(className + suffix).GetValue(context);
            return val as DbSet<TValue>;
        }
        static readonly string suffix = "s";
    }
}
