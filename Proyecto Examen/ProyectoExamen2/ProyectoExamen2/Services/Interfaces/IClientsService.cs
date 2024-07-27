using ProyectoExamen2.Dto.Clients;
using ProyectoExamen2.Dto.Common;

namespace ProyectoExamen2.Services.Interfaces
{
    public interface IClientsService
    {
        Task<ResponseDto<ClientsDto>> CreateClientAsync(ClientCreateDto dto);
        Task<ResponseDto<ClientsDto>> GetClientByIdAsync(Guid id);
        Task<ResponseDto<List<ClientsDto>>> GetListClientsAsync();
    }
}
