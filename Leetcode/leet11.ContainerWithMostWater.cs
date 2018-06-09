using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ContainerWithMostWater
{
	//思路解法： 
	//从左右两端开始，因为他们间隔最大。
	//如果想找一个面积更大的，由于面积是由较低的那根线决定的，所以我们移动较低的线才会有可能面积更大。
	public int MaxArea(int[] height)
	{
		int result = 0;
		int left = 0;
		int right = height.Length - 1;
		while (left < right)
		{
			result = Math.Max(result, CaculateArea(height, left, right));
			if (height[left] <= height[right]) left++;
			else right--;
		}
		return result;

	}

	public int CaculateArea(int[] height, int left, int right)
	{
		return (right - left) * Math.Min(height[left], height[right]);
	}
}

