using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoExamen2.Database;
using ProyectoExamen2.Dto.Clients;
using ProyectoExamen2.Dto.Common;
using ProyectoExamen2.Services.Interfaces;

namespace ProyectoExamen2.Services
{
    public class ClientsService : IClientsService
    {
        private readonly ProyectoExamenContext _context;
        private readonly IMapper _mapper;

        public ClientsService(ProyectoExamenContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ResponseDto<List<ClientsDto>>> GetListClientsAsync()
        {
            var clientsEntitie = await _context.Cliente.ToListAsync();
            var clientsDtos = _mapper.Map<ClientsDto>(clientsEntitie);

            return new ResponseDto<List<ClientsDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de Categorías obtenida correctamente.",
                Data = clientsDtos
            };
        }

        public async Task<ResponseDto<ClientsDto>> CreateClient(ClientCreateDto dto)
        {

        }
    }
}
