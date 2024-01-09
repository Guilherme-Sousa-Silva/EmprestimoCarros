using EmprestimoCarros.API.Enums;

namespace EmprestimoCarros.API.ValueObjects
{
	public class Document
	{
		public Document(string number, EDocumentType type)
		{
			Number = number;
			Type = type;
		}

		public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

		public bool validate()
		{
			if (Type == EDocumentType.CNPJ && Number.Length == 14)
				return true;

			if (Type == EDocumentType.CPF && Number.Length == 13)
				return true;

			return false;
		}
    }
}
