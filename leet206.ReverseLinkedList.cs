using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leet206
{
    //Definition for singly-linked list.
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
 
    public class Solution
    {
        public ListNode ReverseList1(ListNode head)
        {
            ListNode newHead = null;
            while (head != null)
            {
                ListNode nextNode = head.next;
                head.next = newHead;
                newHead = head;
                head = nextNode;
            }
            return newHead;
        }

        public ListNode ReverseList2(ListNode head)
        {
            if (head != null && head.next != null)
            {
                ListNode reversed = ReverseList2(head.next);
                head.next.next = head;
                head.next = null;
                return reversed;
            }
            return head;
        }
    }
}
