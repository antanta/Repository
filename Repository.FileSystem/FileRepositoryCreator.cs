using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.FileSystem
{
    public class FileRepositoryCreator : IRepositoryCreator
    {
        public Repository<T> GetRepository<T>()
            where T : class
        {
            //FileStream
            string fileName = typeof(T).Name + suffix;
            Repository<T> repository = new FileSystemRepository<T>(fileName, new Func<T, object>(FileKeySelector<T>));

            return repository;
        }

        static object FileKeySelector<TValue>(TValue entity)
        {
            /* Could be done with a switch to skip Reflection. Also can look for [Key] attribute */
            object val = entity.GetType().GetProperty(fileIdPropName).GetValue(entity);
            return val;
        }
        static readonly string fileIdPropName = "Id";
        static readonly string suffix = "s";
    }
}
