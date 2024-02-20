using EmprestimoCarros.Application.DTOs.LedingDTOs;
using EmprestimoCarros.Application.Interfaces;
using EmprestimoCarros.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoCarros.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LendingController : ControllerBase
	{
		private readonly ILendingService _lendingService;

		public LendingController(ILendingService lendingService)
		{
			_lendingService = lendingService;
		}

		[HttpGet("get/{id:int}")]
		public async Task<IActionResult> Get(
			[FromRoute] int id) 
		{
			return Ok(await _lendingService.GetById(id));
		}

		[HttpGet("get-all")]
		public async Task<ActionResult<IList<LendingDTO>>> GetAll()
		{
			return Ok(await _lendingService.GetAll());
		}

		[HttpPost("create")]
		public async Task<IActionResult> Create(
			[FromBody] LendingPostDTO lendingPostDTO)
		{
			return Ok(await _lendingService.Create(lendingPostDTO));
		}

		[HttpPut("edit")]
		public async Task<IActionResult> Edit(
			[FromBody] LendingPutDTO lendingPutDTO)
		{
			return Ok(await _lendingService.Update(lendingPutDTO));
		}

		[HttpDelete("delete")]
		public async Task<IActionResult> Delete(
			[FromRoute] int id)
		{
			var car = await _lendingService.GetById(id);

			if (car == null)
			{
				return NotFound($"Carro não encontrado com o Id {id}");
			}

			return Ok(await _lendingService.Delete(id));
		}
	}
}
