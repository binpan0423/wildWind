using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leet8
{
    public class Solution 
    {
        public int MyAtoi(string str) 
        {
            //空strig
            if (str.Length == 0) return 0;

            //跳过空格
            int startIndex = 0;
            while(str[startIndex] == ' ')
            {
                startIndex++;
                if (startIndex > str.Length - 1) return 0;
            }

            //得到+ - 号
            int sign = 1;
            if (str[startIndex] == '+' || str[startIndex] == '-')
            {
                sign = str[startIndex] == '+' ? 1 : -1;
                startIndex++;
            }

            Console.WriteLine("startIndex:" + startIndex);

            // 转换数字,并且防止溢出
            int total = 0;
            while (startIndex < str.Length)
            {
                int digit = str[startIndex] - '0';
                Console.WriteLine("digit:" + digit);
                if (digit < 0 || digit > 9) break;

                if (sign == 1)
                {
                    if (int.MaxValue / 10 < total || int.MaxValue / 10 == total && int.MaxValue % 10 < digit)
                        return int.MaxValue;
                }
                else if (sign == -1)
                {   
                    int minDiv10 = -(int.MinValue/10);
                    int minComplementation10 = -(int.MinValue%10);
                    if (minDiv10 < total || minDiv10 == total && minComplementation10 < digit)
                    {
                        return int.MinValue;
                    }
                }


                total = 10 * total + digit;
                startIndex++;

                //不能采用这种方式，溢出之后得到的total 会有问题
                //if (total >= int.MaxValue && sign == 1) return int.MaxValue;
                //else if (total + int.MinValue >=0 && sign == -1) return int.MinValue;
                //else startIndex++;
            }
            return total * sign;
        }
    }
}
