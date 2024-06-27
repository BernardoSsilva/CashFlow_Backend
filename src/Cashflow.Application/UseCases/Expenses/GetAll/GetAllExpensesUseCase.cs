using AutoMapper;
using Cashflow.Application.UseCases.Expenses.GetAll.Interfaces;
using Cashflow.Communication.Responses.expenses;
using Cashflow.Domain.Repositories.expenses;

namespace Cashflow.Application.UseCases.Expenses.GetAll
{
    public class GetAllExpensesUseCase : IGetAllExpensesUseCase
    {

        private IMapper _mapper;
        private readonly IExpensesRepository _repository;

        public GetAllExpensesUseCase(IMapper mapper, IExpensesRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<MultipleExpensesResponse> Execute()
        {
            var result = await _repository.getAll();
            return new MultipleExpensesResponse
            {
                Expenses = _mapper.Map<List<ShortExpenseResponse>>(result)
            };
        }
    }
}
