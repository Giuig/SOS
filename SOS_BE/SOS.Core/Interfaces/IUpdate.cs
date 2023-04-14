using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Core.Interfaces
{
    public interface IUpdate<T> where T : class
    {
        Task Update(int id, T entity);
    }
}
