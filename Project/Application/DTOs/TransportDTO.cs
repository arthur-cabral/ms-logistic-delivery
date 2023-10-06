using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TransportDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public long SaleId { get; set; }
    }
}
