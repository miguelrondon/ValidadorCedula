using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class CedulaValidator
    {
        public CedulaValidator()
        {

        }
        public bool CheckCedulaIsValid(string cedula)
        {
           
            string input = cedula.Replace("-", "");
            
             if(input.Length != 11) 
                return false;
            
            int lastDigit = Convert.ToInt32(input.Substring(10,1));
            int digit = computeCheckDigit(multiplyCheckFactorByEachDigitAndGetSummation(input));

            return (digit == lastDigit) ? true : false;
        }
        private int computeCheckDigit(int sum)
        {
            int mod = sum % 10;

            return mod == 0 ? 0 : (10 - mod);
        }
        private int multiplyCheckFactorByEachDigitAndGetSummation(string cedula)
        {
            List<int> multipliers = new List<int> { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int sum = 0;
            for (int i = 0; i < multipliers.Count; i++)
            {
                var d = Convert.ToInt32(cedula[i].ToString()) * multipliers[i];
                if (d >= 10)                    
                    d = (d % 10) + ((d - (d % 10)) / 10);
                sum += d;
            }
            return sum;            
        }
    }
}
