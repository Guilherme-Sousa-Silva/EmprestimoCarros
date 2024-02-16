//using EmprestimoCarros.API.Data;
//using EmprestimoCarros.API.Entity;
//using EmprestimoCarros.API.Interfaces;
//using EmprestimoCarros.API.Models;
//using EmprestimoCarros.Domain.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace EmprestimoCarros.API.Repositories.Car
//{
//	public class CarRepository : ICarRepository
//	{
//		private readonly Context _context;

//        public CarRepository(Context context)
//        {
//			_context = context;

//		}
//        public async Task<Entity.Car> GetById(int id)
//		{
//			return await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);

//		}
//		public async Task<IList<Entity.Car>> GetAll()
//		{
//			return await _context.Cars.ToListAsync();
//		}
//		public async Task<Entity.Car> Create(CarModel carModel)
//		{
//			var car = new Entity.Car(
//				carModel.Name, 
//				carModel.Model, 
//				carModel.Brand, 
//				carModel.Year);

//			_context.Add(car);
//			await _context.SaveChangesAsync();

//			return car;
//		}
//		public async Task<Car> Update(int id, CarModel carModel)
//		{
//			var car = await GetById(id);

//			car.Name = carModel.Name;
//			car.Model = carModel.Model;
//			car.Brand = carModel.Brand;
//			car.Year = carModel.Year;

//			_context.Update(car);
//			await _context.SaveChangesAsync();

//			return car;
//		}
//		public async Task<string> Delete(int id)
//		{
//			var car = await GetById(id);

//			_context.Cars.Remove(car);
//			await _context.SaveChangesAsync();
//			return "Carro deletado com sucesso!";
//		}
//	}
//}
