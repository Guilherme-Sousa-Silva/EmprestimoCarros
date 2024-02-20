using EmprestimoCarros.Domain.Entities;
using EmprestimoCarros.Domain.Interfaces;
using EmprestimoCarros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoCarros.Infra.Data.Repositories
{
	public class LendingRepository : ILendingRepository
	{
		private readonly ApplicationDbContext _context;

		public LendingRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<CustomerLendingCar> GetById(int id)
		{
			return await _context.CustomerLendingCars
				.Include(x => x.Customer)
				.Include(x => x.Car)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IList<CustomerLendingCar>> GetAll()
		{
			return await _context.CustomerLendingCars
				.Include(x => x.Customer)
				.Include(x => x.Car)
				.ToListAsync();
		}

		public async Task<CustomerLendingCar> Create(CustomerLendingCar lending)
		{
			await _context.AddAsync(lending);
			await _context.SaveChangesAsync();
			return lending;
		}

		public async Task<CustomerLendingCar> Update(CustomerLendingCar lending)
		{
			_context.Update(lending);
			await _context.SaveChangesAsync();
			return lending;
		}

		public async Task Delete(int id)
		{
			var lending = await GetById(id);
			_context.Remove(lending);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> IsCarOnLoan(int carId)
		{
			var filteredCar = await _context.CustomerLendingCars
				.Where(car => car.Id == carId).FirstOrDefaultAsync();

			if (filteredCar == null)
				return false;

			return true;
		}
	}
}
