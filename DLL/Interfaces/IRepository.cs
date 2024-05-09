using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T values);
        void Delete(T values);
        void Update(T values);
        T GetByName(string name);
    }
}
