namespace EmprestimoCarros.Domain.Entities
{
	public class Car
	{
		public Car(string name, string model, string brand, string year)
		{
			Name = name;
			Model = model;
			Brand = brand;
			Year = year;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Model { get; set; }
		public string Brand { get; set; }
		public string Year { get; set; }

        public IList<CustomerLendingCar> Lendings { get; set; }
    }
}
