
using API.Dto.Entry;
using API.Dto.Output;
using AutoMapper;
using Domain.Entity;

namespace API.Profiles;
    public class MappingProdiles : Profile
    {
        public MappingProdiles(){
            CreateMap<Usuario, UsuarioEntryDto>()
            // Entradas
            .ForMember(e => e.Nombre, opt => opt.MapFrom(x => x.Persona.Nombre))
            .ForMember(e => e.Correo, opt => opt.MapFrom(x => x.Persona.Correo))
            .ReverseMap();
            CreateMap<Departamento, DepartamentoEntryDto>()
            .ForMember(e => e.NombreDepartamento, opt => opt.MapFrom(x => x.NombreDepartamento))
            .ForMember(e => e.NombreDivision, opt => opt.MapFrom(x => x.Division.Name))
            .ForMember(e => e.NombreLocalidad, opt => opt.MapFrom(x => x.Localidad.Nombre))
            .ReverseMap();
            CreateMap<Contrato, ContratoEntryDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoEntryDto>()
            .ForMember(e => e.CargoNombre, opt => opt.Ignore())
            .ForMember(e => e.Nombre, opt => opt.MapFrom(x => x.Persona.Nombre))
            .ForMember(e => e.Correo, opt => opt.MapFrom(x => x.Persona.Correo))
            .ReverseMap();
            CreateMap<Cargo, CargoEntryDto>().ReverseMap();
            //Salidas
            CreateMap<Empleado, EmpleadoDto>()
            .ForMember(e => e.Correo, dest => dest.MapFrom(x => x.Persona.Correo))
            .ForMember(e => e.Nombre, dest => dest.MapFrom(x => x.Persona.Nombre))
            .ForMember(e => e.Cargo, dest => dest.MapFrom(x => x.Cargo.Nombre))
            .ForMember(e => e.Salario, dest => dest.MapFrom(x => x.Salario))
            .ReverseMap();
            


        }
    }