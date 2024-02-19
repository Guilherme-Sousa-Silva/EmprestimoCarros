using AutoMapper;
using EmprestimoCarros.API.Interfaces;
using EmprestimoCarros.Application.DTOs.CarDTOs;
using EmprestimoCarros.Application.Interfaces;
using EmprestimoCarros.Domain.Entities;

namespace EmprestimoCarros.Application.Services
{
	public class CarService : ICarService
	{
		private readonly ICarRepository _carRepository;
		private readonly IMapper _mapper;

		public CarService(ICarRepository carRepository, IMapper mapper)
		{
			_carRepository = carRepository;
			_mapper = mapper;
		}

		public async Task<CarDTO> GetById(int id)
		{
			var car = await _carRepository.GetById(id);
			return _mapper.Map<CarDTO>(car);
		}

		public async Task<IList<CarDTO>> GetAll()
		{
			var cars = await _carRepository.GetAll();
			return _mapper.Map<IList<CarDTO>>(cars);
		}

		public async Task<CarDTO> Create(CarDTO carDTO)
		{
			var car = _mapper.Map<Car>(carDTO);
			var createdCar = await _carRepository.Create(car);
			return _mapper.Map<CarDTO>(createdCar);
		}
		public async Task<CarDTO> Update(CarDTO carDTO)
		{
			var car = _mapper.Map<Car>(carDTO);
			var updatedCar = await _carRepository.Update(car);
			return _mapper.Map<CarDTO>(updatedCar);
		}

		public async Task<string> Delete(int id)
		{
			await _carRepository.Delete(id);
			return "Carro deletado com sucesso!";
		}
	}
}
