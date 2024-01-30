using EmprestimoCarros.API.Data;
using EmprestimoCarros.API.Entity;
using EmprestimoCarros.API.Interfaces;
using EmprestimoCarros.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoCarros.API.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly Context _context;

        public CustomerRepository(Context context)
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

        public async Task<Customer> Create(CustomerModel model)
		{
			var customer = new Customer(
				model.Name, 
				model.CPF,
				model.Street,
				model.City,
				model.Number,
				model.PhoneNumber,
				model.Email);

			_context.Add(customer);
			await _context.SaveChangesAsync();

			return customer;
		}
		public async Task<Customer> Update(int id, CustomerModel model)
		{
			var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

			customer.Name = model.Name;
			customer.Document = model.CPF;
			customer.Street = model.Street;
			customer.City = model.City;
			customer.Number = model.Number;
			customer.PhoneNumber = model.PhoneNumber;
			customer.Email = model.Email;

			_context.Update(customer);
			await _context.SaveChangesAsync();

			return customer;
		}

		public async Task<string> Delete(int id)
		{
			var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

			_context.Remove(customer);
			await _context.SaveChangesAsync();

			return "Cliente deletado com sucesso!";
		}

	}
}
