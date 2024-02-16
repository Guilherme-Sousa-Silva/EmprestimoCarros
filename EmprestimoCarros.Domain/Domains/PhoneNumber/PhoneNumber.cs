using EmprestimoCarros.Domain.Validation;

namespace EmprestimoCarros.Domain.Domains.PhoneNumber
{
	public class PhoneNumber
	{
        public PhoneNumber(string cellphone)
        {
            Validate(cellphone);
        }
        public string CellPhone { get; private set; }

		public void Validate(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new DomainExceptionValidation("Número de telefone não pode ser nulo!");
			}

			CellPhone = value;
		}
    }
}
