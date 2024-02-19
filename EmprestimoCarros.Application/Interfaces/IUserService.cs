using EmprestimoCarros.Application.DTOs.UserDTOs;
using EmprestimoCarros.Domain.Entities;

namespace EmprestimoCarros.Application.Interfaces
{
	public interface IUserService
	{
		Task<UserDTO> GetById(int id);

		Task<IList<UserDTO>> GetAll();

		Task<UserDTO> Create(UserDTO user);

		Task<UserDTO> Update(UserDTO user);

		Task Delete(int id);
	}
}
