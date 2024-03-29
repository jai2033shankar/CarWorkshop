﻿using AutoMapper;
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
                    .ForMember(x => x.CarModel, opt => opt.MapFrom(src => src.Model));
               cfg.CreateMap<Employee, EmployeeDTO>()
                    .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.PositionNavigation.Description))
                    .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.UserRoleNavigation.Name));
               cfg.CreateMap<EmployeeDTO, Employee>()
                    .ForMember(x => x.Password, opt => opt.Condition(y => y.Password != null))
                    .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.PositionId))
                    .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.UserRoleId));

               cfg.CreateMap<CarDTO, Car>()
                    .ForMember(x => x.Model, opt => opt.MapFrom(src => src.CarModel))
                    .ForMember(x => x.Repair, opt => opt.Ignore());

               cfg.CreateMap<Repair, RepairDTO>();
               cfg.CreateMap<RepairDTO, Repair>();

           }).CreateMapper();
        
    }
}
