using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.DTOs;
using AutoMapper;

namespace WebApplication2.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Proyecto, ProyectoDto>().ReverseMap(); // Crear el Dto y ver mapeo!
        }
    }
}
