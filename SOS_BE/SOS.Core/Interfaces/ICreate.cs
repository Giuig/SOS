using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Core.Interfaces
{
    public interface ICreate<T> where T : class
    {
        public Task Create(T dto);

    }
}
