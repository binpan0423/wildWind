using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MyStack
{

    private Queue<int> queue;
    /** Initialize your data structure here. */
    public MyStack()
    {
        queue = new Queue<int>();
    }

    /** Push element x onto stack. */
    public void Push(int x)
    {
        queue.Enqueue(x);
        for (int i = 0; i != queue.Count -1 ; ++i)
        {
            queue.Enqueue(queue.Peek());
            queue.Dequeue();
        }

    }

    /** Removes the element on top of the stack and returns that element. */
    public int Pop()
    {
        return queue.Dequeue();
    }

    /** Get the top element. */
    public int Top()
    {
        return queue.Peek();
    }

    /** Returns whether the stack is empty. */
    public bool Empty()
    {
        return queue.Count == 0;
    }
}
