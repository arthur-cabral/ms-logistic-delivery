using Application.DTOs;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EventProcessor
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        public EventProcessor(IMapper mapper, IServiceScopeFactory scopeFactory)
        {
            _mapper = mapper;
            _scopeFactory = scopeFactory;
        }

        public void Process(string message)
        {
            using var scope = _scopeFactory.CreateScope();

            var transportRepository = scope.ServiceProvider.GetRequiredService<ITransportRepository>();
            var saleReadDto = JsonSerializer.Deserialize<SaleReadDTO>(message);
        }
    }
}
