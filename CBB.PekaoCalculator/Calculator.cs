using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBB.PekaoCalculator
{

    public interface ICalculator
    {
        decimal Calculate(decimal amount, byte period, decimal rate);
    }

    public class Calculator : ICalculator
    {
        public decimal Calculate(decimal amount, byte period, decimal rate)
        {
            return amount + amount * rate;
        }
    }
}
