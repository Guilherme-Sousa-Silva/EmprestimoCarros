using EmprestimoCarros.Domain.Entities;

namespace EmprestimoCarros.API.Interfaces
{
	public interface ICarRepository
	{
		Task<Car> GetById(int id);
		Task<IList<Car>> GetAll();
		Task<Car> Create(Car car);
		Task<Car> Update(Car car);
		Task Delete(int id);
	}
}
