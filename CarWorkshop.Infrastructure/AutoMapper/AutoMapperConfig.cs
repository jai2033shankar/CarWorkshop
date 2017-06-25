using AutoMapper;
using CarWorkshop.Core.Models;
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
               cfg.CreateMap<Client, ClientDTO>();
               cfg.CreateMap<ClientDTO, Client>();
               cfg.CreateMap<Employee, EmployeeDTO>()
                    .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.SalaryNavigation))
                    .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.PositionNavigation.Description));
               cfg.CreateMap<Salary, SalaryDTO>()
                .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary1));
           }).CreateMapper();
        
    }
}
