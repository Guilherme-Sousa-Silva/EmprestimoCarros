using EmprestimoCarros.Domain.Validation;
using System.IO;

namespace EmprestimoCarros.Domain.Domains.Address
{
	public class Address
	{
		public Address(string street, string city, string number)
		{
			ValidateStreet(street);
			ValidatCity(city);
			ValidateNumber(number);
		}

		public string Street { get; private set; }
		public string City { get; private set; }
		public string Number { get; private set; }

		public void ValidateStreet(string street)
		{
			if (string.IsNullOrEmpty(street))
				throw new DomainExceptionValidation("Nome da rua não pode estar em branco!");

			Street = street;
		}

		public void ValidatCity(string city)
		{
			if (string.IsNullOrEmpty(city))
				throw new DomainExceptionValidation("Estado não pode estar em branco!");

			City = city;
		}

		public void ValidateNumber(string number)
		{
			if (string.IsNullOrEmpty(number))
				throw new DomainExceptionValidation("Número da casa não pode ser nulo!");

			Number = number;
		}
	}
}
