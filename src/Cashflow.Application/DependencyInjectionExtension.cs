using Cashflow.Application.AutoMapper;
using Cashflow.Application.UseCases.Expenses.Create;
using Cashflow.Application.UseCases.Expenses.Create.interfaces;
using Cashflow.Application.UseCases.Expenses.DeleteExpense;
using Cashflow.Application.UseCases.Expenses.DeleteExpense.interfaces;
using Cashflow.Application.UseCases.Expenses.GetAll;
using Cashflow.Application.UseCases.Expenses.GetAll.Interfaces;
using Cashflow.Application.UseCases.Expenses.GetById;
using Cashflow.Application.UseCases.Expenses.GetById.Interfaces;
using Cashflow.Application.UseCases.Expenses.UpdateExpense;
using Cashflow.Application.UseCases.Expenses.UpdateExpense.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cashflow.Application
{
    public static class DependencyInjectionExtension
    {

        public static void AddApplication(this IServiceCollection service)
        {
           
            AddAutoMapper(service);
            AddUseCases(service);
        }


        private static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(AutoMapping));
        }
        private static void AddUseCases(IServiceCollection service) {
            service.AddScoped<IRegisterExpenseUseCase, CreateNewExpenseUseCase>();
            service.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
            service.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
            service.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
            service.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
        }
    }
}
