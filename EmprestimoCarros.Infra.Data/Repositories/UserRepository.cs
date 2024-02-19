using EmprestimoCarros.Domain.Entities;
using EmprestimoCarros.Domain.Interfaces;
using EmprestimoCarros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoCarros.Infra.Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<User> GetById(int id)
		{
			var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

			return user;
		}
		public async Task<IList<User>> GetAll()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task<User> Create(User user)
		{
			await _context.AddAsync(user);
			await _context.SaveChangesAsync();

			return user;
		}
		public async Task<User> Update(User user)
		{
			_context.Update(user);
			await _context.SaveChangesAsync();

			return user;
		}

		public async Task Delete(User user)
		{
			_context.Remove(user);
			await _context.SaveChangesAsync();
		}
	}
}
