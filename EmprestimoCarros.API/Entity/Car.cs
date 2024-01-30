namespace EmprestimoCarros.API.Entity
{
	public class Car
	{
		public Car(string name, string model, string brand, DateTime year)
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
        public DateTime Year { get; set; }
        public IList<Customer> Customers { get; set; }
    }
}
