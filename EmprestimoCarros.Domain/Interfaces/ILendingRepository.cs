using EmprestimoCarros.Domain.Entities;

namespace EmprestimoCarros.Domain.Interfaces
{
	public interface ILendingRepository
	{
		Task<CustomerLendingCar> GetById(int id);
		Task<IList<CustomerLendingCar>> GetAll();
		Task<CustomerLendingCar> Create(CustomerLendingCar lending);
		Task<CustomerLendingCar> Update(CustomerLendingCar lending);
		Task Delete(int id);
		Task<bool> IsCarOnLoan(int id);
	}
}
