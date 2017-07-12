using AutoMapper;
using CarWorkshop.Core.Models;
using CarWorkshop.Infrastructure.Commands.Client;
using CarWorkshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshop.Infrastructure.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Configure()
        => new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Client, ClientDTO>()
                    .ForMember(dest => dest.Cars, opt => opt.MapFrom(src => src.Car));
               cfg.CreateMap<ClientDTO, Client>()
                    .ForMember(x => x.Password, opt => opt.Condition(y => y.Password != null))
                    .ForMember(x => x.UserRole, opt => opt.Condition(y => y.UserRole != null));
               cfg.CreateMap<CreateClient, ClientDTO>();

               cfg.CreateMap<Car, CarDTO>()
                    .ForMember(dest => dest.RegistratrionNumber, opt => opt.MapFrom(src => src.RegistrationNumber));
               cfg.CreateMap<Employee, EmployeeDTO>()
                    .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.PositionNavigation.Description));
               cfg.CreateMap<EmployeeDTO, Employee>();
           }).CreateMapper();
        
    }
}
