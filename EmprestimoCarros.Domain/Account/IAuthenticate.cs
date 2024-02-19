using EmprestimoCarros.Domain.Entities;

namespace EmprestimoCarros.Domain.Account
{
	public interface IAuthenticate
	{
		Task<bool> AuthenticateAsync(string email, string senha);
		Task<bool> UserExist(string email);
		public string GenerateToken(int id, string email);
		public Task<User> GetUserByEmail(string email);
    }
}
