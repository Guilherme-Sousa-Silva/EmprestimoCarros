using AutoMapper;
using EmprestimoCarros.API.DTOs;
using EmprestimoCarros.API.DTOs.CustomerDTOs;
using EmprestimoCarros.Domain.Entities;

namespace EmprestimoCarros.API.Mappings
{
    public class EntitiesToDtoMappingProfile : Profile
	{
        public EntitiesToDtoMappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
			CreateMap<Customer, CreateOrEditCustomerDTO>().ReverseMap();
		}
    }
}
