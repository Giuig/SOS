using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Core.Interfaces
{
    public interface IGetById
    {
        public interface IGetById<T> where T : class
        {
            public T GetById(int id);
        }
    }
}
