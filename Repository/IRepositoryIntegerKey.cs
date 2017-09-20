using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryIntegerKey<TValue> : IRepository<TValue, int>
        where TValue: class
    {
    }
}
