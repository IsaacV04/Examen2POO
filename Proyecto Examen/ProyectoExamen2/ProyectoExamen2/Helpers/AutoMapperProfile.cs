using AutoMapper;
using ProyectoExamen2.Database.Entities;
using ProyectoExamen2.Dto.Clients;

namespace ProyectoExamen2.Helpers
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            MapsForClients();
        }

        private void MapsForClients()
        {
            CreateMap<ClienteEntity, ClientsDto>();
            CreateMap<ClientCreateDto, ClienteEntity>();
            CreateMap<ClientEditDto, ClienteEntity>();
        }
    }
}
