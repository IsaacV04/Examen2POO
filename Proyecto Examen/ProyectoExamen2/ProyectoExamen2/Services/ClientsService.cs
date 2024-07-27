using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoExamen2.Database;
using ProyectoExamen2.Database.Entities;
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
            var clientsEntities = await _context.Cliente.ToListAsync();
            var clientsDtos = _mapper.Map<List<ClientsDto>>(clientsEntities);

            return new ResponseDto<List<ClientsDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de Categorías obtenida correctamente.",
                Data = clientsDtos
            };
        }

        public async Task<ResponseDto<ClientsDto>> GetClientByIdAsync(Guid id)
        {
            try
            {
                var clientEntity = await _context.Cliente.FirstOrDefaultAsync(c => c.Id == id);
                if (clientEntity == null)
                {
                    return new ResponseDto<ClientsDto>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Cliente no encontrado."
                    };
                }

                var clientDto = _mapper.Map<ClientsDto>(clientEntity);
                return new ResponseDto<ClientsDto>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Cliente encontrado.",
                    Data = clientDto
                };
            }
            catch (Exception ex)
            {
                // Log exception
                return new ResponseDto<ClientsDto>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseDto<ClientsDto>> CreateClientAsync(ClientCreateDto dto)
        {
            var clientEntity = _mapper.Map<ClienteEntity>(dto);

            _context.Cliente.Add(clientEntity);
            await _context.SaveChangesAsync();

            var clientDto = _mapper.Map<ClientsDto>(clientEntity);

            return new ResponseDto<ClientsDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Cliente creada correctamente.",
                Data = clientDto
            };
        }
    }
}
