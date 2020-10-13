
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
/*
24. 两两交换链表中的节点
给定一个链表，两两交换其中相邻的节点，并返回交换后的链表。

你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。

 此题可以通过迭代和递归两种写法解决，比较常规，代码如下
*/
public class Solution
{
    //递归法
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null || head.next == null) return head;
        ListNode p1 = head;
        ListNode p2 = p1.next;
        ListNode p3 = p2.next;
        p2.next = p1;
        p1.next = SwapPairs(p3);
        return p2;
    }
    //迭代法
    public ListNode SwapPairs66(ListNode head)
    {
        ListNode dummy = new ListNode(0);
        ListNode cur = dummy;
        dummy.next = head;
        ListNode first = null;
        ListNode second = null;
        ListNode tmp = null;
        while (cur.next != null && cur.next.next != null)
        {
            first = cur.next;
            second = first.next;
            tmp = second.next;

            cur.next = second;
            second.next = first;
            first.next = tmp;
            cur = first;
        }
        return dummy.next;
    }
}