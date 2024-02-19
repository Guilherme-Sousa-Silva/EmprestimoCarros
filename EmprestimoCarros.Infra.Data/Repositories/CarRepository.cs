using EmprestimoCarros.API.Interfaces;
using EmprestimoCarros.Domain.Entities;
using EmprestimoCarros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoCarros.API.Repositories
{
	public class CarRepository : ICarRepository
	{
		private readonly ApplicationDbContext _context;

		public CarRepository(ApplicationDbContext context)
		{
			_context = context;

		}
		public async Task<Car> GetById(int id)
		{
			return await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);

		}
		public async Task<IList<Car>> GetAll()
		{
			return await _context.Cars.ToListAsync();
		}
		public async Task<Car> Create(Car car)
		{
			_context.Add(car);
			await _context.SaveChangesAsync();
			return car;
		}
		public async Task<Car> Update(Car car)
		{
			_context.Update(car);
			await _context.SaveChangesAsync();
			return car;
		}
		public async Task Delete(int id)
		{
			var car = await GetById(id);
			_context.Cars.Remove(car);
			await _context.SaveChangesAsync();
		}
	}
}
