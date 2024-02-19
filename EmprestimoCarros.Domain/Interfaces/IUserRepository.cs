using EmprestimoCarros.Domain.Entities;

namespace EmprestimoCarros.Domain.Interfaces
{
	public interface IUserRepository
	{
		Task<User> GetById(int id);

		Task<IList<User>> GetAll();

		Task<User> Create(User user);

		Task<User> Update(User user);

		Task Delete(User user);
	}
}
