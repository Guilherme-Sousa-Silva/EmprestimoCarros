using EmprestimoCarros.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprestimoCarros.API.Data.Mappings
{
	public class CarMap : IEntityTypeConfiguration<Car>
	{
		public void Configure(EntityTypeBuilder<Car> builder)
		{
			// Nomeando a tabela
			builder.ToTable("Car");

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
