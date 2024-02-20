using EmprestimoCarros.API.DTOs;
using EmprestimoCarros.Application.DTOs.CarDTOs;
using EmprestimoCarros.Domain.Entities;

namespace EmprestimoCarros.Application.DTOs.LedingDTOs
{
	public class LendingDTO
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int CarId { get; set; }
		public DateTime LendingDate { get; set; }
		public DateTime DeliveryDate { get; set; }
		public bool Delivered { get; set; }
		public CustomerDTO CustomerDTO { get; set; }
		public CarDTO carDTO { get; set; }
	}
}
