using EmprestimoCarros.Application.DTOs.CarDTOs;

namespace EmprestimoCarros.Application.Interfaces
{
	public interface ICarService
	{
		public Task<CarDTO> GetById(int id);
		public Task<IList<CarDTO>> GetAll();
		public Task<CarDTO> Create(CarDTO carDTO);
		public Task<CarDTO> Update(CarDTO carDTO);
		public Task<string> Delete(int id);
	}
}
