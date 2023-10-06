using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EventProcessor
{
    public interface IEventProcessor
    {
        void Process(string message);
    }
}
