namespace EmprestimoCarros.API.Entity
{
	public class Customer
	{
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
