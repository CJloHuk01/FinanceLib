using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLib.Services
{
    public class FinancialHistory
    {
        private List<string> _operations = new List<string>();

        public void AddOperation(string operation)
        {
            _operations.Add($"{DateTime.Now:dd.MM.yyyy HH:mm}: {operation}");
        }

        public void DisplayHistory()
        {
            if (_operations.Count == 0)
            {
                Console.WriteLine("История операций пуста");
                return;
            }

            Console.WriteLine("История операций:");
            foreach (var operation in _operations)
            {
                Console.WriteLine(operation);
            }
        }
    }
