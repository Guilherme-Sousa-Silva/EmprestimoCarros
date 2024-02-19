using EmprestimoCarros.API.Models;
using EmprestimoCarros.Application.DTOs.UserDTOs;
using EmprestimoCarros.Application.Interfaces;
using EmprestimoCarros.Domain.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoCarros.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IAuthenticate _authenticate;

        public UserController(IUserService userService, IAuthenticate authenticate)
        {
			_userService = userService;
			_authenticate = authenticate;
		}

		[HttpPost("register")]
		public async Task<ActionResult<UserToken>> Register(
			[FromBody] UserDTO userDto)
		{
			if (userDto == null)
			{
				return BadRequest("Dados inválidos");
			}

			var emailExists = await _authenticate.UserExist(userDto.Email);
			if (emailExists)
			{
				return BadRequest("Este e-mail já possui um cadastro");
			}

			var user = await _userService.Create(userDto);
			if (user == null)
			{
				return BadRequest("Ocorreu um erro ao cadastrar");
			}

			var token = _authenticate.GenerateToken(user.Id, user.Email); ;
			return new UserToken
			{
				Token = token,
			};
		}

		[HttpPost("login")]
		public async Task<ActionResult<UserToken>> Login(
			[FromBody] UserLogin userLogin)
		{
			var exist = await _authenticate.UserExist(userLogin.Email);
			if (!exist)
			{
				return Unauthorized("E-mail não existe!");
			}

			var result = await _authenticate.AuthenticateAsync(userLogin.Email, userLogin.Password);
			if (!result)
			{
				return BadRequest("Usuário ou senha inválidos.");
			}

			var user = await _authenticate.GetUserByEmail(userLogin.Email);
			var token = _authenticate.GenerateToken(user.Id, user.Email);

			return new UserToken
			{
				Token = token,
			};
		}
    }
}
