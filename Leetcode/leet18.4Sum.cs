using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCode.leetcode
{
    class leet18
    {
        //思路：
        //1: 2Sum Problem
        //2: Reduce K Sum problem => K-1 Sum problem
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            return KSum(nums, 0, 4, target);
        }

        private List<IList<int>> KSum(int[] nums, int start, int k, int target)
        {
            int len = nums.Length;
            List<IList<int>> res = new List<IList<int>>();
            if (len - start < k) return res; //数目不够直接返回
            if (k == 2)
            {
                //2Sum问题
                int left = start, right = len - 1;
                while (left < right)
                {
                    int sum = nums[left] + nums[right];
                    if (sum == target)
                    {
                        List<int> path = new List<int>();
                        path.Add(nums[left]);
                        path.Add(nums[right]);
                        res.Add(path);
                        //跳过重复的返回值
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        left++;
                        right--;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else if (sum > target)
                    {
                        right--;
                    }
                }

            }
            else
            {
                for (int i = start; i != len - (k - 1); ++i)
                {
                    if (i > start && nums[i] == nums[i - 1]) continue;//跳过重复的
                    List<IList<int>> temp = KSum(nums, i + 1, k - 1, target - nums[i]);//递归
                    foreach(List<int> t in temp){
                        t.Insert(0, nums[i]);//加入自己
                    }
                    res.AddRange(temp);
                }
            }
            return res;
        }
    }
}
