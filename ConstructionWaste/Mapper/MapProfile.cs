using AutoMapper;
using ConstructionWaste.DTOs.Car;
using ConstructionWaste.DTOs.Clients;
using ConstructionWaste.DTOs.Registration;
using ConstructionWaste.DTOs.User;
using DAL.Models;
using Services.JoinClasses;

namespace ConstructionWaste.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AppUser, RegistrerUserDTO>();
            CreateMap<RegistrerUserDTO, AppUser>();
            CreateMap<EditUserDTO, AppUser>();

            CreateMap<Client, ClientsDTO>();
            CreateMap<ClientJ, ClientsDTO>();
            CreateMap<Client, ClientTest>();
            CreateMap<ClientTest, Client>();
            CreateMap<ClientTypeDTO, ClientType>();
            CreateMap<ClientType, ClientTypeDTO>();
            //CreateMap<Client, CreateClient>();
            CreateMap<CreateClient, Client>();

            CreateMap<CarJDriver, CarJDriverDTO>();
            CreateMap<Car, CarDTO>();
            CreateMap<CarDriver, CarDriverDTO>();

            CreateMap<CarDTO, Car>();
            CreateMap<CarDriverDTO, CarDriver>();


            


        }
    }
}
