namespace EmprestimoCarros.Domain.Entities
{
	public class CustomerLendingCar
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int CarId { get; set; }
		public DateTime LendingDate { get; set; }
		public DateTime DeliveryDate { get; set; }
		public bool Delivered { get; set; }
		public Customer Customer { get; set; }
		public Car Car { get; set; }
	}
}
