namespace EmprestimoCarros.Domain.Entities
{
	public class User
	{
		public User(int id, string name, string email)
		{
			Id = id;
			Name = name;
			Email = email;
			IsAdmin = false;
		}

		public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsAdmin { get; private set; }
        public byte[] PasswordHash { get; private set; }
		public byte[] PasswordSalt { get; private set; }

		public void SetPasswordHash(byte[] passwordHash, byte[] passwordSalt)
		{
			PasswordHash = passwordHash;
			PasswordSalt = passwordSalt;
		}

		public void SetUserAsAdmin(bool isAdmin)
		{
			IsAdmin = isAdmin;
		}
	}
}
