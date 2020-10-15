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
/*
给定一个完美二叉树，其所有叶子节点都在同一层，每个父节点都有两个子节点。二叉树定义如下：

struct Node {
  int val;
  Node *left;
  Node *right;
  Node *next;
}
填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL。

初始状态下，所有 next 指针都被设置为 NULL。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
*/

//这题对二叉树做了限制，是满二叉树，下一题去掉了这个限制，但是依然可以O1空间复杂度完成
public class Solution
{
    //常规解法，二叉树的层序遍历
    //空间复杂度n
    public Node Connect(Node root)
    {
        if (root == null) return root;
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);
        while (q.Count != 0)
        {
            int cnt = q.Count;
            for (int i = 0; i < cnt; i++)
            {
                Node cur = q.Dequeue();
                if (i != cnt - 1)
                    cur.next = q.Peek();
                if (cur.left != null)
                    q.Enqueue(cur.left);
                if (cur.right != null)
                    q.Enqueue(cur.right);
            }
        }
        return root;
    }
    //迭代写法
    public Node Connect111(Node root)
    {
        if (root == null) return root;
        Node pre = root;
        Node cur = null;
        while (pre.left != null)
        {
            cur = pre;
            while (cur != null)
            {
                cur.left.next = cur.right;
                if (cur.next != null)
                    cur.right.next = cur.next.left;
                cur = cur.next;
            }
            pre = pre.left;
        }
        return root;
    }
    //递归写法
    public Node Connect222(Node root)
    {
        if (root == null) return root;
        Node l = root.left;
        Node r = root.right;
        while (l != null)
        {
            l.next = r;
            l = l.right;
            r = r.left;
        }
        Connect(root.left);
        Connect(root.right);
        return root;
    }

    //下一题的解法
    public Node Connect333(Node root)
    {
        if (root == null) return root;
        Node cur = root;
        Node dummy = new Node(0);
        Node p = dummy;
        while (cur != null)
        {
            while (cur != null)
            {
                if (cur.left != null)
                {
                    p.next = cur.left;
                    p = p.next;
                }
                if (cur.right != null)
                {
                    p.next = cur.right;
                    p = p.next;
                }
                cur = cur.next;
            }
            cur = dummy.next;
            dummy.next = null;
            p = dummy;
        }
        return root;
    }
}