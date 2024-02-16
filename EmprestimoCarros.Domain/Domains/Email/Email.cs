using EmprestimoCarros.Domain.Validation;

namespace EmprestimoCarros.Domain.Domains.Email
{
	public class Email
	{
		public Email(string emailAddress)
		{
			Validate(emailAddress);
		}

        public string EmailAddress { get; private set; }

		public void Validate(string value)
		{
			if (string.IsNullOrEmpty(value)){
				throw new DomainExceptionValidation("E-mail não pode ser nulo!");
			}

			EmailAddress = value;
		}
    }
}
