using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mycodingpractice
{
    public class MinStack
    {

        /** initialize your data structure here. */
        List<int> dataStack = new List<int>();
        List<int> minStack = new List<int>();

        public MinStack()
        {

        }

        public void Push(int x)
        {
            dataStack.Add(x);
            if (minStack.Count == 0 || minStack[minStack.Count - 1] >= x)
            {
                minStack.Add(x);
            }
        }

        public void Pop()
        {
            if (minStack.Count  > 0 &&  minStack[minStack.Count - 1] == dataStack[dataStack.Count - 1])
            {
                minStack.RemoveAt(minStack.Count - 1);
            }
            if (dataStack.Count > 0)
            {
                dataStack.RemoveAt(dataStack.Count - 1);
            }
        }

        public int Top()
        {
            if (dataStack.Count > 0)
                return dataStack[dataStack.Count - 1];
            else
                return 0;
        }

        public int GetMin()
        {
            if (minStack.Count > 0)
                return minStack[minStack.Count - 1];
            else
                return 0;
        }
    }
}
