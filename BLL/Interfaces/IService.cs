using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService <T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T values);
        void Delete(T values);
        void Update(T values);
        T GetByName(string name);
    }
}
