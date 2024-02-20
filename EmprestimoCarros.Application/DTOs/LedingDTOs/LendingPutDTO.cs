namespace EmprestimoCarros.Application.DTOs.LedingDTOs
{
	public class LendingPutDTO
	{
		public int Id { get; set; }
		public int CarId { get; set; }
		public DateTime DeliveryDate { get; set; }
		public bool Delivered { get; set; }
	}
}
