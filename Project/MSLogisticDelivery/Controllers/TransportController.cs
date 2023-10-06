using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/sale/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private ITransportService _transportService;

        public TransportController(ITransportService transportService)
        {
            _transportService = transportService;
        }

        [HttpPost]
        public ActionResult CreateTransportRequest(SaleReadDTO saleDTO)
        {
            Console.WriteLine(saleDTO.Id);
            return Ok();
        }
    }
}
