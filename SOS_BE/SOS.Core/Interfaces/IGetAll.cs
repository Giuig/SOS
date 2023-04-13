using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Core.Interfaces
{
    public interface IGetAll<T> where T : class
    {
        public IEnumerable<T> GetAll();

    }
}
