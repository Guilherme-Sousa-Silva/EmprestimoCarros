using EmprestimoCarros.API.Entity;
using EmprestimoCarros.API.Models;

namespace EmprestimoCarros.API.Interfaces
{
	public interface ICarRepository
	{
		Task<Car> GetById(int id);
		Task<IList<Car>> GetAll();
		Task<Car> Create(CarModel carModel);
		Task<Car> Update(int id, CarModel carModel);
		Task<string> Delete(int id);
	}
}
