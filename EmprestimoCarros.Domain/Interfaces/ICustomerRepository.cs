using EmprestimoCarros.Domain.Entities;

namespace EmprestimoCarros.API.Interfaces
{
	public interface ICustomerRepository
	{
		Task<Customer> GetById(int id);

		Task<IList<Customer>> GetAll();

		Task<Customer> Create(Customer customer);
		
		Task<Customer> Update(Customer createOrEditCustomerDTO);

		Task Delete(Customer customer);
	}
}
