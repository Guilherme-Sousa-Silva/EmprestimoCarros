using EmprestimoCarros.API.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprestimoCarros.API.Data.Mappings
{
	public class CustomerLendingCarMap : IEntityTypeConfiguration<CustomerLendingCar>
	{
		public void Configure(EntityTypeBuilder<CustomerLendingCar> builder)
		{
			// Nomeando a tabela
			builder.ToTable("CustomerLendingCar");

			// Definindo chave primária
			builder.HasKey(x => x.Id);

			// Configurando identity do Id
			builder.Property(x => x.Id)
				.ValueGeneratedOnAdd()
				.UseIdentityColumn();

			// Propriedades da tabela
			builder.Property(x => x.CustomerId)
				.IsRequired() // NOT NULL
				.HasColumnName("CustomerId") // Nome da coluna
				.HasColumnType("INT"); // Tipo de dados

			builder.Property(x => x.CarId)
				.IsRequired() // NOT NULL
				.HasColumnName("CarId") // Nome da coluna
				.HasColumnType("INT"); // Tipo de dados

			builder.Property(x => x.LendingDate)
				.IsRequired() // NOT NULL
				.HasColumnName("LendingDate") // Nome da coluna
				.HasColumnType("SMALLDATETIME") // Tipo de dados
				.HasDefaultValueSql("GETDATE()"); // Configura como valor padrão a data atual

			builder.Property(x => x.DeliveryDate)
				.HasColumnName("DeliveryDate") // Nome da coluna
				.HasColumnType("SMALLDATETIME"); // Tipo de dados

			builder.Property(x => x.Delivered)
				.IsRequired()
				.HasColumnName("Delivered")
				.HasColumnType("BIT");
		}
	}
}
