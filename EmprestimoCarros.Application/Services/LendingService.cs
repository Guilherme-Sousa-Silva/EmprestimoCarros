using AutoMapper;
using EmprestimoCarros.Application.DTOs.LedingDTOs;
using EmprestimoCarros.Application.Interfaces;
using EmprestimoCarros.Domain.Entities;
using EmprestimoCarros.Domain.Interfaces;
using EmprestimoCarros.Domain.Validation;

namespace EmprestimoCarros.Application.Services
{
	public class LendingService : ILendingService
	{
		private readonly ILendingRepository _lendingRepository;
		private readonly IMapper _mapper;

		public LendingService(ILendingRepository lendingRepository, IMapper mapper)
		{
			_lendingRepository = lendingRepository;
			_mapper = mapper;
		}

		public async Task<LendingDTO> GetById(int id)
		{
			var lending = await _lendingRepository.GetById(id);
			return _mapper.Map<LendingDTO>(lending);
		}

		public async Task<IList<LendingDTO>> GetAll()
		{
			var lendings = await _lendingRepository.GetAll();
			return _mapper.Map<IList<LendingDTO>>(lendings);
		}

		public async Task<LendingDTO> Create(LendingPostDTO lendingPostDTO)
		{

			var carIsLoan = await _lendingRepository.IsCarOnLoan(lendingPostDTO.CarId);

			if (carIsLoan)
			{
				throw new DomainExceptionValidation("Esse carro já está emprestado!");
			}
			var lending = _mapper.Map<CustomerLendingCar>(lendingPostDTO);

			lending.SetDelivered(false);
			lending.SetLendingDate(DateTime.Now);

			var createdLending = await _lendingRepository.Create(lending);
			return _mapper.Map<LendingDTO>(createdLending);
		}

		public async Task<LendingDTO> Update(LendingPutDTO lendingPutDTO)
		{
			var lending = _mapper.Map<CustomerLendingCar>(lendingPutDTO);
			var updatedLending = await _lendingRepository.Update(lending);
			return _mapper.Map<LendingDTO>(updatedLending);
		}

		public async Task<string> Delete(int id)
		{
			await _lendingRepository.Delete(id);
			return "Emprestimo de carro deletado com sucesso!";
		}

		public async Task<string> ReturnCar(int id)
		{
			var lending = await _lendingRepository.GetById(id);
			lending.SetDelivered(true);
			lending.SetDeliveryDate(DateTime.Now);
			await _lendingRepository.Update(lending);
			return "Carro devolvido com sucesso!";
		}
	}
}
