using EmprestimoCarros.API.Interfaces;
using EmprestimoCarros.Domain.Entities;
using EmprestimoCarros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoCarros.API.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<Customer> GetById(int id)
		{
			var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);


			return customer;
		}
		public async Task<IList<Customer>> GetAll()
		{
			return await _context.Customers.ToListAsync();
		}

		public async Task<Customer> Create(Customer customer)
		{
			_context.Add(customer);
			await _context.SaveChangesAsync();

			return customer;
		}
		public async Task<Customer> Update(Customer customer)
		{
			_context.Update(customer);
			await _context.SaveChangesAsync();

			return customer;
		}

		public async Task Delete(Customer customer)
		{
			_context.Remove(customer);
			await _context.SaveChangesAsync();
		}

	}
}
