using AutoMapper;
using EmprestimoCarros.API.DTOs;
using EmprestimoCarros.API.DTOs.CustomerDTOs;
using EmprestimoCarros.Application.DTOs.CarDTOs;
using EmprestimoCarros.Application.DTOs.LedingDTOs;
using EmprestimoCarros.Application.DTOs.UserDTOs;
using EmprestimoCarros.Domain.Entities;

namespace EmprestimoCarros.API.Mappings
{
    public class EntitiesToDtoMappingProfile : Profile
	{
        public EntitiesToDtoMappingProfile()
        {
            // customer
            CreateMap<Customer, CustomerDTO>().ReverseMap();
			CreateMap<Customer, CreateOrEditCustomerDTO>().ReverseMap();

            // user
            CreateMap<User, UserDTO>().ReverseMap();

            // car
            CreateMap<Car, CarDTO>().ReverseMap();

            // lending car
            CreateMap<LendingDTO, CustomerLendingCar>().ReverseMap()
                .ForMember(dest => dest.carDTO, opt => opt.MapFrom(x => x.Car))
				.ForMember(dest => dest.CustomerDTO, opt => opt.MapFrom(x => x.Customer));

            CreateMap<CustomerLendingCar, LendingPostDTO>().ReverseMap();
			CreateMap<CustomerLendingCar, LendingPutDTO>().ReverseMap();
		}
    }
}
