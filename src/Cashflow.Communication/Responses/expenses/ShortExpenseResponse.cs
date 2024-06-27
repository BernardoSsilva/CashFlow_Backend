﻿namespace Cashflow.Communication.Responses.expenses
{
    public class ShortExpenseResponse
    {
        public long Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
    }
}
