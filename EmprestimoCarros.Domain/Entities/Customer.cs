
namespace EmprestimoCarros.Domain.Entities
{
	public class Customer
	{
		public Customer(string name, string document, string street, string city, string number, string phoneNumber, string email)
		{
			Name = name;
			Document = document;
			Street = street;
			City = city;
			Number = number;
			PhoneNumber = phoneNumber;
			Email = email;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public string Document { get; private set; }
		public string Street { get; private set; }
		public string City { get; private set; }
		public string Number { get; private set; }
		public string PhoneNumber { get; private set; }
		public string Email { get; private set; }
        public IList<CustomerLendingCar> Lendings { get; set; }
    }
}
