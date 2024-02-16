using EmprestimoCarros.Domain.Entities;

namespace EmprestimoCarros.API.Interfaces
{
	public interface ICarRepository
	{
		Task<Car> GetById(int id);
		Task<IList<Car>> GetAll();
		Task<Car> Create(Car car);
		Task<Car> Update(int id, Car car);
		Task<string> Delete(int id);
	}
}
