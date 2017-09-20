using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<TValue, TKey>
    {
        void Insert(TValue value);
        void Insert(IEnumerable<TValue> values);
        void Remove(TValue obj);
        void RemoveAll(IEnumerable<TValue> objects = null);
        void RemoveByKey(TKey key);
        void RemoveAllByKey(IEnumerable<TKey> keys);
        void SaveChanges();
        bool Exists(TValue obj);
        bool ExistsByKey(TKey key);
        void Update<TUpdate>(TKey key, TUpdate updateObj);
        void Update<TUpdate, TProperty>(TKey key, TUpdate updateObj, Func<TValue, TProperty> getter);
        void Update(TKey key, String json, UpdateType updateType);
        void Update(TKey key, String pathToProperty, String json, UpdateType updateType);
        ObjectContext<TValue> Find(TKey key);
        EnumerableObjectContext<TValue> Items { get; }
        ReadOnlyRepository<TValue, TKey> AsReadOnly();
    }
}
