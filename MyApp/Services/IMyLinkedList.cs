using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public interface IMyLinkedList<T>
    {
        void Insert(T item, int position);

        void Delete(int position);

        T GetItem(int position);
    }
}
