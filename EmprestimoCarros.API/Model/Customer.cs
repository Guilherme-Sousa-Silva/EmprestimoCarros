using EmprestimoCarros.API.ValueObjects;

namespace EmprestimoCarros.API.Models
{
	public class Customer
	{
		public Customer(int id, Name name, Document cPF, Address address, Contact contact)
		{
			Id = id;
			Name = name;
			CPF = cPF;
			Address = address;
			Contact = contact;
		}

		public int Id { get; private set; }
		public Name Name { get; private set; }
		public Document CPF { get; private set; }
        public Address Address { get; private set; }
        public Contact Contact { get; private set; }
    }
}
