using EmprestimoCarros.API.Entity;
using EmprestimoCarros.API.Interfaces;
using EmprestimoCarros.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoCarros.API.Controllers
{
	[ApiController]
	[Route("api/car")]
	public class CarController : ControllerBase
	{
		private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
			_carRepository = carRepository;

		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get(
			[FromRoute] int id)
		{
			var car = await _carRepository.GetById(id);

			if(car == null)
			{
				return NotFound($"Carro não encontrado pelo Id {id}");
			}

			return Ok(car);
		}

		[HttpGet("get-all")]
		public async Task<ActionResult<IList<Car>>> GetAll()
		{
			return Ok(await _carRepository.GetAll());
		}

		[HttpPost("create")]
		public async Task<IActionResult> Create(
			[FromRoute] CarModel model)
		{
			return Ok( await _carRepository.Create(model));
		}

		[HttpPut("edit/{id:int}")]
		public async Task<IActionResult> Edit(
			[FromRoute] int id,
			[FromBody] CarModel model)
		{
			var car = await _carRepository.GetById(id);

			if (car == null)
			{
				return NotFound($"Carro não encontrado com o Id {id}");
			}

			return Ok(await _carRepository.Update(id, model));
		}

		[HttpPut("delete/{id:int}")]
		public async Task<IActionResult> Delete(
			[FromRoute] int id)
		{
			var car = await _carRepository.GetById(id);

			if (car == null)
			{
				return NotFound($"Carro não encontrado com o Id {id}");
			}

			return Ok(await _carRepository.Delete(id));
		}
	}
}
