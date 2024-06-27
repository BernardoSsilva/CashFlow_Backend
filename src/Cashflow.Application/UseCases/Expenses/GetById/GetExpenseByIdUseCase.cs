using AutoMapper;
using Cashflow.Application.UseCases.Expenses.GetById.Interfaces;
using Cashflow.Communication.Responses.expenses;
using Cashflow.Domain.Repositories.expenses;

namespace Cashflow.Application.UseCases.Expenses.GetById
{
    public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
    {
        private readonly IMapper _mapper;
        private readonly IExpensesRepository _repository;
        public GetExpenseByIdUseCase(IMapper mapper, IExpensesRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<DetaildedExpenseResponse> Execute(long id)
        {
            var result = await _repository.getById(id);
 
            return _mapper.Map<DetaildedExpenseResponse>(result);
 
        }
    }
}
