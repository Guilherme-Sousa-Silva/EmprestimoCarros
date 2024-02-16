using AutoMapper;
using EmprestimoCarros.API.DTOs;
using EmprestimoCarros.API.DTOs.CustomerDTOs;
using EmprestimoCarros.API.Interfaces;
using EmprestimoCarros.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoCarros.API.Controllers
{
	[ApiController]
	[Route("api/customer")]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;
		private readonly IMapper _mapper;

		public CustomerController(ICustomerService customerService, IMapper mapper)
		{
			_customerService = customerService;
			_mapper = mapper;

		}

		[HttpGet("get-by/{id:int}")]
		public async Task<IActionResult> Get(
			[FromRoute] int id)
		{
			var customer = await _customerService.GetById(id);

			if (customer == null)
			{
				return NotFound($"Cliente não encontrado pelo Id {id}");
			}

			return Ok(customer);
		}

		[HttpGet("get-all")]
		public async Task<ActionResult<IList<CustomerDTO>>> GetAll()
		{
			var customers = await _customerService.GetAll();

			return Ok(customers);
		}

		[HttpPost("create")]
		public async Task<IActionResult> Create(
			[FromBody] CustomerDTO customerDto)
		{
			var customer = await _customerService.Create(customerDto);

			if (customer == null)
			{
				return BadRequest("Ocorreu um erro ao incluir o cliente!");
			}

			return Ok(customer);
		}

		[HttpPut("edit")]
		public async Task<IActionResult> Edit(
			[FromBody] CustomerDTO customerDto)
		{
			var customer = await _customerService.GetById(customerDto.Id);

			if (customer == null)
			{
				return NotFound($"Cliente não encontrado pelo Id {customerDto.Id}");
			}

			return Ok(await _customerService.Update(customerDto));
		}

		[HttpDelete("delete/{id:int}")]
		public async Task<IActionResult> Delete(
			[FromRoute] int id)
		{
			var customer = await _customerService.GetById(id);

			if (customer == null)
			{
				return NotFound($"Cliente não encontrado pelo Id {id}");
			}

			return Ok(await _customerService.Delete(id));
		}
	}
}
