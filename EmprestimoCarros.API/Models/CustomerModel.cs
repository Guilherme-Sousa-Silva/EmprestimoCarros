using EmprestimoCarros.API.ValueObjects;

namespace EmprestimoCarros.API.Models
{
	public class CustomerModel
	{
		public CustomerModel(string name, string cPF, string street, string city, string number, string phoneNumber, string email)
		{
			Name = name;
			CPF = cPF;
			Street = street;
			City = city;
			Number = number;
			PhoneNumber = phoneNumber;
			Email = email;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public string CPF { get; private set; }
		public string Street { get; private set; }
		public string City { get; private set; }
		public string Number { get; private set; }
		public string PhoneNumber { get; private set; }
		public string Email { get; private set; }
	}
}
