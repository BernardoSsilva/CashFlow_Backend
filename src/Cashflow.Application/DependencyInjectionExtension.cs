using Cashflow.Application.AutoMapper;
using Cashflow.Application.UseCases.Expenses.Create;
using Cashflow.Application.UseCases.Expenses.Create.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cashflow.Application
{
    public static class DependencyInjectionExtension
    {

        public static void AddApplication(this IServiceCollection service)
        {
            service.AddScoped<IRegisterExpenseUseCase, CreateNewExpenseUseCase>();
            AddAutoMapper(service);
            AddUseCases(service);
        }


        private static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(typeof (AutoMapping));
             }
        private static void AddUseCases(IServiceCollection service) { }
    }
}
