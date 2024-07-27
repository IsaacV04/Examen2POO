using Microsoft.AspNetCore.Mvc;
using ProyectoExamen2.Dto.Clients;
using ProyectoExamen2.Dto.Common;
using ProyectoExamen2.Services.Interfaces;

namespace ProyectoExamen2.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            this._clientsService = clientsService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<ClientsDto>>>> GetAll()
        {
            var response = await _clientsService.GetListClientsAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<ClientsDto>>> Get(Guid id)
        {
            var response = await _clientsService.GetClientByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<ClientsDto>>> Create(ClientCreateDto dto)
        {
            var response = await _clientsService.CreateClientAsync(dto);
            return StatusCode(response.StatusCode, response);
        }
    }
}
