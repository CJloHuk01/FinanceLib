using FinanceLib.Models;
using FinanceLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLib
{
    public class Finance
    {
        private FinancialHistory _history = new FinancialHistory();

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n=== Финансовая библиотека ===");
                Console.WriteLine("1 - Кредитный калькулятор");
                Console.WriteLine("2 - Конвертер валют");
                Console.WriteLine("3 - История операций");
                Console.WriteLine("0 - Выход");
                Console.Write("Выберите операцию: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunCreditCalculator();
                        break;
                    case "2":
                        RunCurrencyConverter();
                        break;
                    case "3":
                        _history.DisplayHistory();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }

        private void RunCreditCalculator()
        {
            try
            {
                var data = new CreditData();

                Console.Write("Сумма кредита: ");
                data.Amount = double.Parse(Console.ReadLine());

                Console.Write("Срок (месяцев): ");
                data.Months = int.Parse(Console.ReadLine());

                Console.Write("Процентная ставка (%): ");
                data.InterestRate = double.Parse(Console.ReadLine());

                var calculator = new CreditCalculator(data);
                string result = calculator.Execute();

                Console.WriteLine("\n" + result);
                _history.AddOperation($"Кредит: {data.Amount} руб, {data.Months} мес, {data.InterestRate}%");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private void RunCurrencyConverter()
        {
            try
            {
                var data = new CurrencyData();

                Console.Write("Сумма: ");
                data.Amount = double.Parse(Console.ReadLine());

                Console.Write("Из валюты (usd, eur, rub): ");
                data.FromCurrency = Console.ReadLine().ToLower();

                Console.Write("В валюту (usd, eur, rub): ");
                data.ToCurrency = Console.ReadLine().ToLower();

                var converter = new CurrencyConverter(data);
                string result = converter.Execute();

                Console.WriteLine("\n" + result);
                _history.AddOperation($"Конвертация: {data.Amount} {data.FromCurrency}->{data.ToCurrency}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}

