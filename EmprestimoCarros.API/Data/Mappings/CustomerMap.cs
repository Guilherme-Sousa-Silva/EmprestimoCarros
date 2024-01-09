using EmprestimoCarros.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprestimoCarros.API.Data.Mappings
{
	public class CustomerMap : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			// Nomeando a tabela
			builder.ToTable("Customer");

			// Definindo chave primária
			builder.HasKey(x => x.Id);

			// Configurando identity do Id
			builder.Property(x => x.Id)
				.ValueGeneratedOnAdd()
				.UseIdentityColumn();

			// Propriedades da tabela

			builder.Property(x => x.Name)
				.IsRequired() // NOT NULL
				.HasColumnName("Name") // Nome da coluna
				.HasColumnType("NVARCHAR") // Tipo de dados
				.HasMaxLength(40); // Maximo de caracteres

			builder.Property(x => x.Document)
				.IsRequired() // NOT NULL
				.HasColumnName("Document") // Nome da coluna
				.HasColumnType("NVARCHAR") // Tipo de dados
				.HasMaxLength(15); // Maximo de caracteres

			builder.Property(x => x.Street)
				.IsRequired() // NOT NULL
				.HasColumnName("Street") // Nome da coluna
				.HasColumnType("NVARCHAR") // Tipo de dados
				.HasMaxLength(40); // Maximo de caracteres

			builder.Property(x => x.City)
				.IsRequired() // NOT NULL
				.HasColumnName("City") // Nome da coluna
				.HasColumnType("NVARCHAR") // Tipo de dados
				.HasMaxLength(2); // Maximo de caracteres

			builder.Property(x => x.Number)
				.IsRequired() // NOT NULL
				.HasColumnName("Number") // Nome da coluna
				.HasColumnType("NVARCHAR") // Tipo de dados
				.HasMaxLength(10); // Maximo de caracteres

			builder.Property(x => x.PhoneNumber)
				.IsRequired() // NOT NULL
				.HasColumnName("PhoneNumber") // Nome da coluna
				.HasColumnType("NVARCHAR") // Tipo de dados
				.HasMaxLength(15); // Maximo de caracteres

			builder.Property(x => x.Email)
				.IsRequired() // NOT NULL
				.HasColumnName("Email") // Nome da coluna
				.HasColumnType("NVARCHAR") // Tipo de dados
				.HasMaxLength(50); // Maximo de caracteres
		}
	}
}
