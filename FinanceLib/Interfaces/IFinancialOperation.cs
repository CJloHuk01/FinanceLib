using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLib.Interfaces
{
    public interface IFinancialOperation
    {
        string Execute();
        string GetDescription();
    }
}
