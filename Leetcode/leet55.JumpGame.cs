using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCode.leetcode
{
    class leet55
    {
        public bool CanJump(int[] nums)
        {
            int rightMost = 1; // 最远能到第几个，从1开始计算。最右边的是nums.Length
            for (int i = 0; i != nums.Length; ++i)
            {
                if (rightMost < i + 1) break; //到不了下一个，之后的也不用考虑了。
                rightMost = Math.Max(rightMost, i + 1 + nums[i]); 
            }
            return rightMost >= nums.Length;
        }
    }
}
