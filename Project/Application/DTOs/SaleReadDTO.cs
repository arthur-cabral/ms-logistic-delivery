using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SaleReadDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public long CompanyId { get; set; }
    }
}
