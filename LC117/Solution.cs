using System.Collections.Generic;
public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}


public class Solution
{
    //利用队列BFS，本质还是层序遍历
    //空间复杂度On
    public Node Connect(Node root)
    {
        if (root == null) return root;
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            int cnt = queue.Count;
            for (int i = 0; i < cnt; i++)
            {
                Node cur = queue.Dequeue();
                if (i < cnt - 1)
                    cur.next = queue.Peek();
                if (cur.left != null)
                    queue.Enqueue(cur.left);
                if (cur.right != null)
                    queue.Enqueue(cur.right);
            }
        }
        return root;
    }

    //空间复杂度O1
    //利用虚拟节点记住下一层的第一个节点
    //不容易想到
    public Node Connect666(Node root)
    {
        Node cur = root;
        while (cur != null)
        {
            Node dummy = new Node(0);
            Node tail = dummy;
            while (cur != null)
            {
                if (cur.left != null)
                {
                    tail.next = cur.left;
                    tail = tail.next;
                }
                if (cur.right != null)
                {
                    tail.next = cur.right;
                    tail = tail.next;
                }
                cur = cur.next;
            }
            cur = dummy.next;
        }
        return root;
    }
}