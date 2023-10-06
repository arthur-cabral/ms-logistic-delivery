using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TransportService : ITransportService
    {
        public Task ChangeSaleStatus(long id)
        {
            return Task.CompletedTask;
        }
    }
}
