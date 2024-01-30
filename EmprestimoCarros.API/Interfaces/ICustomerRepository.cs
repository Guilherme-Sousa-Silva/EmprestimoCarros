using EmprestimoCarros.API.Entity;
using EmprestimoCarros.API.Models;

namespace EmprestimoCarros.API.Interfaces
{
	public interface ICustomerRepository
	{
		Task<Customer> GetById(int id);

		Task<IList<Customer>> GetAll();

		Task<Customer> Create(Models.CustomerModel customer);
		
		Task<Customer> Update(int id, CustomerModel customer);

		Task<string> Delete(int id);
	}
}
