using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Algorithm
{
    class TraversalBinaryTree
    {
       
       //   Definition for a binary tree node.
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        //二叉树的遍历 
        public TraversalBinaryTree()
        {


        }

        


        List<int> ret = new List<int>();

        //递归 中序遍历  就是中根遍历
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root != null)
            {
                if (root.left != null) InorderTraversal(root.left);
                ret.Add(root.val); //就是add，不会有concat这种东西
                if (root.right != null) InorderTraversal(root.right);
            }
            return ret;
        }


        //https://juejin.im/post/59e3fde451882578c20858a5
        //https://www.jianshu.com/p/456af5480cee
        //先序和中序代码大部分是一致的，
        //非递归  使用Stack 先序
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;

            while (current != null || stack.Count != 0)
            {
                while (current != null)
                {
                    result.Add(current.val); //先序
                    stack.Push(current);
                    current = current.left;
                }

                if (stack.Count != 0)
                {
                    current = stack.Pop();
                    current = current.right;                 
                }
            }
            return result;
        }

        //中序非递归遍历
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;
            while (current != null || stack.Count != 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                if (stack.Count != 0)
                {
                    current = stack.Pop();
                    result.Add(current.val); //中序
                    current = current.right;
                }
            }
            return result;
        }


        //后序遍历，需要记录其右节点是否已经遍历过
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;
            TreeNode lastVisit = root;
            while (current != null || stack.Count != 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }


                //查看当前栈顶元素
                current = stack.Peek();

                //如果右子树为空，或者已经访问过，输出当前
                if (current.right == null || current.right == lastVisit)
                {
                    result.Add(current.val);
                    stack.Pop();
                    lastVisit = current; //记录
                    current = null; //继续弹栈
                }
                else
                {
                    //否则，继续遍历右子树
                    current = current.right;
                }

            }
            return result;
        }


    }
}
