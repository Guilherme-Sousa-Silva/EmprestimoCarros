namespace EmprestimoCarros.API.Entity
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

		public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public string Number { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IList<Car> Cars { get; set; }

    }
}
