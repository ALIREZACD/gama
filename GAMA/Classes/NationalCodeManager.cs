using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAMA.Classes
{
    public static class NationalCodeManager
    {
        public static bool IsValid(string nationalCode)
        {
            if (nationalCode.Length != 10)
                return false;
            int sum = 0;
            for (int i = 2; i <= 10; i++)
            {
                int num = nationalCode[10 - i] - 48;
                sum += num * i;
            }
            int controlNum = nationalCode[9] - 48;
            int divid = sum % 11;
            return (((divid < 2) && (controlNum == divid)) || ((divid >= 2) && ((11 - divid) == controlNum)));
        }
    }
}
