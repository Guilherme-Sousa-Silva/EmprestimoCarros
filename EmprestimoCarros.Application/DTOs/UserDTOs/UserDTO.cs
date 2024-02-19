using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoCarros.Application.DTOs.UserDTOs
{
	public class UserDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		[NotMapped]
        public string Password { get; set; }
    }
}
