using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Azure
{
    public class AzureRepositoryCreator : IRepositoryCreator
    {
        public Repository<T> GetRepository<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
