using EmprestimoCarros.API.DTOs;

namespace EmprestimoCarros.Application.Interfaces
{
	public interface ICustomerService
	{
		Task<CustomerDTO> GetById(int id);

		Task<IList<CustomerDTO>> GetAll();

		Task<CustomerDTO> Create(CustomerDTO customer);

		Task<CustomerDTO> Update(CustomerDTO customerDTO);

		Task<string> Delete(int id);
	}
}
