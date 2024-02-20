using EmprestimoCarros.Application.DTOs.LedingDTOs;

namespace EmprestimoCarros.Application.Interfaces
{
	public interface ILendingService
	{
		Task<LendingDTO> GetById(int id);
		Task<IList<LendingDTO>> GetAll();
		Task<LendingDTO> Create(LendingPostDTO lendingPostDTO);
		Task<LendingDTO> Update(LendingPutDTO lendingPutDTO);
		Task<string> Delete(int id);
		Task<string> ReturnCar(int id);
	}
}
