using EmprestimoCarros.API.Interfaces;
using EmprestimoCarros.Application.DTOs.CarDTOs;
using EmprestimoCarros.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoCarros.API.Controllers
{
	[ApiController]
	[Route("api/car")]
	public class CarController : ControllerBase
	{
		private readonly ICarService _carService;

		public CarController(ICarService carService)
		{
			_carService = carService;

		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get(
			[FromRoute] int id)
		{
			var car = await _carService.GetById(id);

			if (car == null)
			{
				return NotFound($"Carro não encontrado pelo Id {id}");
			}

			return Ok(car);
		}

		[HttpGet("get-all")]
		public async Task<ActionResult<IList<CarDTO>>> GetAll()
		{
			return Ok(await _carService.GetAll());
		}

		[HttpPost("create")]
		public async Task<IActionResult> Create(
			[FromBody] CarDTO carDto)
		{
			return Ok(await _carService.Create(carDto));
		}

		[HttpPut("edit")]
		public async Task<IActionResult> Edit(
			[FromBody] CarDTO carDto)
		{
			return Ok(await _carService.Update(carDto));
		}

		[HttpDelete("delete/{id:int}")]
		public async Task<IActionResult> Delete(
			[FromRoute] int id)
		{
			var car = await _carService.GetById(id);

			if (car == null)
			{
				return NotFound($"Carro não encontrado com o Id {id}");
			}

			return Ok( await _carService.Delete(id));
		}
	}
}
