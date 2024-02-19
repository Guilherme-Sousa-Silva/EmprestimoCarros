using EmprestimoCarros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprestimoCarros.Infra.Data.EntitiesConfiguration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			// Nomeando a tabela
			builder.ToTable("User");

			// Definindo chave primária
			builder.HasKey(x => x.Id);

			// Propriedades da tabela
			builder.Property(x => x.Name)
				.IsRequired() // NOT NULL
				.HasColumnName("Name") // Nome da coluna
				.HasColumnType("VARCHAR") // Tipo de dados
				.HasMaxLength(40); // Maximo de caracteres

			// Propriedades da tabela
			builder.Property(x => x.Email)
				.IsRequired() // NOT NULL
				.HasColumnName("Email") // Nome da coluna
				.HasColumnType("VARCHAR") // Tipo de dados
				.HasMaxLength(40); // Maximo de caracteres

			builder.Property(x => x.IsAdmin)
			.IsRequired() // NOT NULL
			.HasColumnName("IsAdmin") // Nome da coluna
			.HasColumnType("BIT"); // Tipo de dados
		}
	}
}
