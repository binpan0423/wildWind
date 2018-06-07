using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class leet415
{
    //"123456" + "141111111"
    public string AddStrings(string num1, string num2)
    {
        //用StringBuilder(mutable)代替string(immutable)
        StringBuilder result = new StringBuilder();
        int carry = 0;
        int i = num1.Length - 1;
        int j = num2.Length - 1;


        while (i >= 0 || j >= 0 || carry == 1)
        {
            int sum = 0;
            if (i >= 0)
            {
                sum += num1[i] - '0';
            }
            if (j >= 0)
            {
                sum += num2[j] - '0';
            }

            sum += carry;
            carry = sum >= 10 ? 1 : 0;
            result = result.Insert(0,(sum %10 ).ToString());
            i--;
            j--;
        }

        return result.ToString();
    }
}