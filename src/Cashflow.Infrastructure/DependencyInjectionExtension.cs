using Cashflow.Domain.Repositories;
using Cashflow.Domain.Repositories.expenses;
using Cashflow.Infrastructure.DataAccess;
using Cashflow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cashflow.Infrastructure
{
    public  static  class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service)
        {
            AddRepositories(service);
            AddDbContext(service);

        }

        private static void AddRepositories(IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IExpensesRepository, ExpensesRepository>();
        }

        private static void AddDbContext(IServiceCollection service)
        {
            var connectionString = "server=localhost:5432;Database=cashflow_db;Uid=root;pwd=@password123";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 37));
            service.AddDbContext<CashflowDbContext>(config => config.UseMySql(connectionString, serverVersion));
        }


    }
}
