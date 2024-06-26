﻿using Cashflow.Domain.entities;

namespace Cashflow.Domain.Repositories.expenses
{
    public interface IExpensesRepository
    {
        Task add(Expense expense);
    }
}
