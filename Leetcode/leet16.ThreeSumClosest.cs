using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class leet16
{
	public int ThreeSumClosest(int[] nums, int target)
	{
		//直接三个循环，时间复杂度不是最优
		//可以考虑先排序，然后调整后两个值
		Array.Sort(nums);
		int sum;
		int result = nums[0] + nums[1] + nums[2];
		for (int i = 0; i != nums.Length - 2; ++i)
		{
			int left = i + 1;
			int right = nums.Length - 1;
			while (left < right)
			{
				sum = nums[i] + nums[left] + nums[right];
				if (Math.Abs(sum - target) < Math.Abs(result-target))
				{
					result = sum; //记录下最接近的值
				}

				if (sum == target) return sum;
				else if (sum < target)
				{
					left++;
				}
				else
				{
					right--;
				}
			}
		}
		return result;
	}
}

