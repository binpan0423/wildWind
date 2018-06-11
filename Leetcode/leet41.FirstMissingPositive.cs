using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCode.leetcode
{
    class leet41
    {
        //Given an unsorted integer array, find the smallest missing positive integer.
        //需要有常数额外空间
        public int FirstMissingPositive(int[] nums)
        {
            //if (nums.Length <= 0) return 1; 
            //HashSet<int> numsSet = new HashSet<int>();
            //for (int i = 0; i != nums.Length; ++i)
            //{
            //    if(!numsSet.Contains(nums[i]))numsSet.Add(nums[i]);
            //}
            //int j = 1;
            //while (true)
            //{
            //    if (numsSet.Contains(j)) j++;
            //    else return j;
            //}

            //把值 x 放到正确的位置上 x-1
            int len = nums.Length;
            int i = 0;
            while (i < len)
            {
                if (nums[i] != i + 1 && nums[i] >= 1 && nums[i] <= len && nums[nums[i] - 1] != nums[i])
                {
                    Swap(ref nums[i], ref nums[nums[i] - 1]);
                }
                else i++;
            }

            for (i = 0; i != len; ++i)
            {
                if (nums[i] != i + 1) return i + 1;
            }
            return len + 1;
        }

        private void Swap(ref int a,ref int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
        }
    }
}
