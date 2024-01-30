using EmprestimoCarros.API.Entity;
using EmprestimoCarros.API.Interfaces;
using EmprestimoCarros.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoCarros.API.Controllers
{
	[ApiController]
	[Route("api/customer")]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
			_customerRepository = customerRepository;

		}

        [HttpGet("get-by/{id:int}")]
		public async Task<IActionResult> Get(
			[FromRoute] int id)
		{
			var customer = await _customerRepository.GetById(id);

			if (customer == null)
			{
				return NotFound($"Cliente não encontrado pelo Id {id}");
			}

			return Ok(await _customerRepository.GetById(id));
		}

		[HttpGet("get-all")]
		public async Task<ActionResult<IList<Entity.Customer>>> GetAll()
		{
			return Ok(await _customerRepository.GetAll());
		}

		[HttpPost("create")]
		public async Task<IActionResult> Create(
			[FromBody] CustomerModel customer)
		{
			return Ok(await _customerRepository.Create(customer));
		}

		[HttpPut("edit/{id:int}")]
		public async Task<IActionResult> Edit(
			[FromRoute] int id,
			[FromBody] CustomerModel model)
		{
			var customer = await _customerRepository.GetById(id);

			if (customer == null)
			{
				return NotFound($"Cliente não encontrado pelo Id {id}");
			}

			return Ok(await _customerRepository.Update(id, model));
		}

		[HttpDelete("delete/{id:int}")]
		public async Task<IActionResult> Delete(
			[FromRoute] int id)
		{
			var customer = await _customerRepository.GetById(id);

			if (customer == null)
			{
				return NotFound($"Cliente não encontrado pelo Id {id}");
			}

			return Ok(await _customerRepository.Delete(id));
		}
	}
}
