using FinanceLib.Interfaces;
using FinanceLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLib.Services
{
    public class CurrencyConverter : IFinancialOperation
    {
        private CurrencyData _data;
        private Dictionary<string, double> _exchangeRates;

        public CurrencyConverter(CurrencyData data)
        {
            _data = data;
            InitializeExchangeRates();
        }

        private void InitializeExchangeRates()
        {
            _exchangeRates = new Dictionary<string, double>
        {
            {"usd_eur", 0.86},
            {"eur_usd", 1.16},
            {"usd_rub", 79.47},
            {"rub_usd", 0.013}
        };
        }

        public string Execute()
        {
            string key = $"{_data.FromCurrency}_{_data.ToCurrency}";

            if (!_exchangeRates.ContainsKey(key))
                return "Ошибка: Неподдерживаемая валютная пара";

            double commission = _data.Amount * _data.CommissionRate;
            double amountAfterCommission = _data.Amount - commission;
            double result = amountAfterCommission * _exchangeRates[key];

            return $"Комиссия: {commission:F2} {_data.FromCurrency.ToUpper()}\n" +
                   $"Результат: {result:F2} {_data.ToCurrency.ToUpper()}";
        }

        public string GetDescription() => "Конвертер валют";
    }

}
