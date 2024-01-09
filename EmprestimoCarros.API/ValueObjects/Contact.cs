namespace EmprestimoCarros.API.ValueObjects
{
	public class Contact
	{
		public Contact(string cellPhoneNumber, string email)
		{
			CellPhoneNumber = cellPhoneNumber;
			Email = email;
		}

		public string CellPhoneNumber { get; private set; }
        public string Email { get; private set; }

		public bool Validate()
		{
			if(string.IsNullOrEmpty(CellPhoneNumber))
				return false;

			if (string.IsNullOrEmpty(Email))
				return false;

			return true;
		}

    }
}
