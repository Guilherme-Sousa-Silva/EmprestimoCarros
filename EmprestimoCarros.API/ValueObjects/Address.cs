namespace EmprestimoCarros.API.ValueObjects
{
	public class Address
	{
		public Address(string rua, string cidade, string bairro, string numero)
		{
			Street = rua;
			City = cidade;
			Neighborhood = bairro;
			Number = numero;
		}

		public string Street { get; private set; }
		public string City { get; private set; }
		public string Neighborhood { get; private set; }
		public string Number { get; private set; }

		public bool Validate()
		{
			if (string.IsNullOrEmpty(Street)) 
				return false;

			if (string.IsNullOrEmpty(City)) 
				return false;

			if (string.IsNullOrEmpty(Neighborhood)) 
				return false;

			if (string.IsNullOrEmpty(Number)) 
				return false;

			return true;
		}
	}
}
