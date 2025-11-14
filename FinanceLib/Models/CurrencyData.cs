using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLib.Models
{
    public class CurrencyData
    {
        public double Amount { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public double CommissionRate { get; set; } = 0.03;
    }
}
