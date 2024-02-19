using System.ComponentModel.DataAnnotations;

namespace EmprestimoCarros.API.Models
{
	public class UserLogin
	{
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }
    }
}
