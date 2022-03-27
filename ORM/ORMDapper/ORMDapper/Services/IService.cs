using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMDapper.Services
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
