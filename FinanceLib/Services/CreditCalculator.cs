using FinanceLib.Interfaces;
using FinanceLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLib.Services
{
    public class CreditCalculator : IFinancialOperation
    {
        private CreditData _data;

        public CreditCalculator(CreditData data)
        {
            _data = data;
        }

        public string Execute()
        {
            double totalAmount = _data.Amount * (1 + _data.InterestRate / 100);
            double overpayment = totalAmount - _data.Amount;
            double monthlyPayment = totalAmount / _data.Months;

            var result = $"Общая сумма выплат: {totalAmount:F2} руб\n";
            result += $"Переплата: {overpayment:F2} руб\n";
            result += $"Ежемесячный платеж: {monthlyPayment:F2} руб\n";
            result += "График платежей:\n";

            for (int i = 1; i <= _data.Months; i++)
            {
                result += $"{i} | платёж: {monthlyPayment:F2} руб\n";
            }

            return result;
        }

        public string GetDescription() => "Кредитный калькулятор";
    }
}
