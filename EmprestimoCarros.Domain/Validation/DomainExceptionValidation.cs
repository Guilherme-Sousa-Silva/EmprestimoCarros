namespace EmprestimoCarros.Domain.Validation
{
	public class DomainExceptionValidation : Exception
	{
        public DomainExceptionValidation(string error) : base(error)
        {
            
        }

        public static void Error(bool hasError, string error)
        {
            if (hasError)
            {
				throw new DomainExceptionValidation(error);
			}
		}
    }
}
