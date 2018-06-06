using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution {
    public int Search(int[] nums, int target) {
         int left = 0;
            int right = nums.Length - 1;
            int middle;
            while (left <= right)
            {
                middle = left + (right - left) / 2;
                if (nums[middle] == target) return middle;
                else if(nums[middle] > nums[right]) // 说明转折点在右边 
                {
                    if (target >= nums[left] && target < nums[middle])
                    {
                        //在左边
                        right = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                else //说明转折点在左边
                {
                    if (target > nums[middle] && target <= nums[right])
                    {
                        //在右边
                        left = middle + 1;
                    }
                    else
                    {
                        right = middle - 1;
                    }
                }
            }
            return -1;
    }
}