namespace EmprestimoCarros.API.Entity
{
	public class CustomerLendingCar
	{
		public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime LendingDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool Delivered { get; set; }
    }
}
