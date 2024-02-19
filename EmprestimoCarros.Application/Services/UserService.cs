using AutoMapper;
using EmprestimoCarros.Application.DTOs.UserDTOs;
using EmprestimoCarros.Application.Interfaces;
using EmprestimoCarros.Domain.Entities;
using EmprestimoCarros.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace EmprestimoCarros.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
			_userRepository = userRepository;
			_mapper = mapper;
		}
		public async Task<UserDTO> GetById(int id)
		{
			var user = await _userRepository.GetById(id);
			return _mapper.Map<UserDTO>(user);
		}

		public async Task<IList<UserDTO>> GetAll()
		{
			var user = await _userRepository.GetAll();
			return _mapper.Map<IList<UserDTO>>(user);
		}

        public async Task<UserDTO> Create(UserDTO userDto)
		{
			var user = _mapper.Map<User>(userDto);

			if(userDto.Password != null)
			{
				using var hmac = new HMACSHA512();
				byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));
				byte[] passwordSalt = hmac.Key;
				user.SetPasswordHash(passwordHash, passwordSalt);
			}

			var createdUser = await _userRepository.Create(user);
			return _mapper.Map<UserDTO>(createdUser);
		}

		public async Task<UserDTO> Update(UserDTO userDto)
		{
			var user = _mapper.Map<User>(userDto);
			var updatedUser = await _userRepository.Update(user);
			return _mapper.Map<UserDTO>(updatedUser);
		}

		public async Task Delete(int id)
		{
			var userDto = await GetById(id);
			var user = _mapper.Map<User>(userDto);
			var deletedUser = _userRepository.Delete(user);
		}
	}
}
