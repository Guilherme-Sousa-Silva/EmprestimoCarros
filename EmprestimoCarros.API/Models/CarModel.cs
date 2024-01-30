namespace EmprestimoCarros.API.Models
{
	public class CarModel
	{
		public CarModel(string name, string model, string brand, DateTime year)
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
	}

}
