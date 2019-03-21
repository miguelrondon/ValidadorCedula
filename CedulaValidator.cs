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
            int lastDigitComputed = LastDigitCheck(cedula.Replace("-",""));
            
            int inputLastDigit = Convert.ToInt32(cedula[cedula.Length-1].ToString()); 
            
            return lastDigitComputed == inputLastDigit ? true : false;
        }
        private int LastDigitCheck(string cedula)
        {
            List<int> multipliers = new List<int> { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int sum = 0;

            for (int i = 0; i < multipliers.Count; i++)
            {
                var d = Convert.ToInt32(cedula[i].ToString()) * multipliers[i];
                if (d >= 10)
                {
                    var mod = (d % 10);
                    sum = sum + mod + ((d - mod) / 10);
                }
                else
                {
                    sum = sum + d;
                }
            }
            var m = sum % 10;
            if (m != 0)
            {
                return 10 - m;
            }
            else return 0;
        }
    }
}
