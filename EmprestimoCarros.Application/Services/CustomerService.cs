using AutoMapper;
using EmprestimoCarros.API.DTOs;
using EmprestimoCarros.API.DTOs.CustomerDTOs;
using EmprestimoCarros.API.Interfaces;
using EmprestimoCarros.Application.Interfaces;
using EmprestimoCarros.Domain.Entities;

namespace EmprestimoCarros.Application.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
			_customerRepository = customerRepository;
			_mapper = mapper;
		}

		public async Task<CustomerDTO> GetById(int id)
		{
			var customer = await _customerRepository.GetById(id);
			return _mapper.Map<CustomerDTO>(customer);
		}

		public async Task<IList<CustomerDTO>> GetAll()
		{
			var customers = await _customerRepository.GetAll();
			return _mapper.Map<IList<CustomerDTO>>(customers);
		}
        public async Task<CustomerDTO> Create(CustomerDTO customerDto)
		{
			var customer = _mapper.Map<Customer>(customerDto);
			var createdCustomer = await _customerRepository.Create(customer);
			return _mapper.Map<CustomerDTO>(createdCustomer);
		}
		public async Task<CustomerDTO> Update(CustomerDTO customerDTO)
		{
			// mapea o customerDTO para customer
			var customer = _mapper.Map<Customer>(customerDTO);

			// chama a função de edição no repositório
			var updatedCustomer = await _customerRepository.Update(customer);

			// retorna o customerDto
			return _mapper.Map<CustomerDTO>(updatedCustomer);
		}

		public async Task<string> Delete(int id)
		{
			var customer = await GetById(id);

			if (customer == null)
				return $"Não foi possivel encontrar o cliente pelo Id {id}";

			var deletedCustomer = _mapper.Map<Customer>(customer);
			await _customerRepository.Delete(deletedCustomer);
			return "Cliente deletado com sucesso!";
		}
	}
}
