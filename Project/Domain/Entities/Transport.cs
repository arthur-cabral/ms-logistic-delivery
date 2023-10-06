using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transport
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public long SaleId { get; set; }
    }
}
