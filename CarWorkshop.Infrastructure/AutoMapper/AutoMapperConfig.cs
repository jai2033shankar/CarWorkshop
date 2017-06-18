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
               cfg.CreateMap<Employee, EmployeeDTO>();
               cfg.CreateMap<ClientDTO, Client>();
           }).CreateMapper();
        
    }
}
