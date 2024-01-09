namespace EmprestimoCarros.API.ValueObjects
{
	public class Name
	{
		public Name(string fullName)
		{
			FullName = fullName;
		}

		public string FullName { get; private set; }
		
		public bool validate()
		{
			if (string.IsNullOrEmpty(FullName))
				 return false;

			return true;
		}
    }
}
