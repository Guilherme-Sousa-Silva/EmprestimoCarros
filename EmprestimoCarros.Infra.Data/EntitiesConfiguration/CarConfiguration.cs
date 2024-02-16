using EmprestimoCarros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprestimoCarros.Infra.Data.EntitiesConfiguration
{
	internal class CarConfiguration : IEntityTypeConfiguration<Car>
	{
		public void Configure(EntityTypeBuilder<Car> builder)
		{
			// Nomeando a tabela
			builder.ToTable("Car");

			// Definindo chave primária
			builder.HasKey(x => x.Id);

			// Propriedades da tabela
			builder.Property(x => x.Name)
				.IsRequired() // NOT NULL
				.HasColumnName("Name") // Nome da coluna
				.HasColumnType("NVARCHAR") // Tipo de dados
				.HasMaxLength(40); // Maximo de caracteres

			builder.Property(x => x.Model)
				.IsRequired() // NOT NULL
				.HasColumnName("Model") // Nome da coluna
				.HasColumnType("NVARCHAR") // Tipo de dados
				.HasMaxLength(20); // Maximo de caracteres

			builder.Property(x => x.Brand)
				.IsRequired() // NOT NULL
				.HasColumnName("Brand") // Nome da coluna
				.HasColumnType("NVARCHAR") // Tipo de dados
				.HasMaxLength(20); // Maximo de caracteres

			builder.Property(x => x.Year)
				.IsRequired() // NOT NULL
				.HasColumnName("Year") // Nome da coluna
				.HasColumnType("SMALLDATETIME") // Tipo de dados
				.HasDefaultValueSql("GETDATE()"); // Configura como valor padrão a data atual
		}
	}
}
