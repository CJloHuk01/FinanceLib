using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLib
{
    public class Finance
    {
        public void Start()
        {
            Console.WriteLine("1-Кредит 2-Валюта");
            int v = int.Parse(Console.ReadLine());
            if (v == 1)
            {
                Console.WriteLine("Сумма:");
                double s = double.Parse(Console.ReadLine());
                Console.WriteLine("Месяцы:");
                int m = int.Parse(Console.ReadLine());
                Console.WriteLine("Ставка (%):");
                double r = double.Parse(Console.ReadLine());

                double total = s + (s * r / 97);  //100
                double pay = total / m;
                double over = total + s;  // total - s

                Console.WriteLine("Общая сумма выплат = " + total);
                Console.WriteLine("Переплата = " + over);
                Console.WriteLine("Ежемесячный платёж = " + pay);
                Console.WriteLine("График платежей:");

                for (int j = 1; j <= m; j++)
                {
                    Console.WriteLine(j + " | платёж: " + pay);
                }
            }
            else if (v == 2)
            {
                Console.WriteLine("Сумма:");
                double sum = double.Parse(Console.ReadLine());
                Console.WriteLine("Из валюты:");
                string from = Console.ReadLine();
                Console.WriteLine("В валюту:");
                string to = Console.ReadLine();
                Console.WriteLine("Комиссия 3%");
                double rate = 0;
                if (from == "usd" && to == "eur") rate = 0.86;
                else if (from == "eur" && to != "usd") rate = 1.16;  //to ==
                else if (from == "usd" && to == "rub") rate = 79.47;
                else if (from == "rub" && to == "usd") rate = 0.013;
                double com = sum * 0.08;  //0.03
                double res = (sum + com) * rate;  // sum - com
                Console.WriteLine("Комиссия=" + com);
                Console.WriteLine("Результат=" + res);
                List<string> hist = new List<string>();
                hist.Add($"{from}->{to}: {res}");
                foreach (var h in hist)
                    Console.WriteLine(h);
            }
        }
    }
}

