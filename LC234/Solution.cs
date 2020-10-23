/*
234. 回文链表
请判断一个链表是否为回文链表。

示例 1:

输入: 1->2
输出: false
示例 2:

输入: 1->2->2->1
输出: true
进阶：
你能否用 O(n) 时间复杂度和 O(1) 空间复杂度解决此题？
*/

//最直观的想法是遍历链表，存入数组中，再左右指针依次判断是否相等
//但是要求空间复杂度O1，常规解法是，找中点、逆序、判断相等
//至于题解区找中点的同时逆序这种写法，真的太骚气了，服气
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution
{
    public bool IsPalindrome111(ListNode head)
    {
        if (head == null || head.next == null) return true;
        ListNode fast = head;
        ListNode slow = head;
        while (fast != null && fast.next != null && fast.next.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        ListNode newhead = slow.next;
        slow.next = null;
        ListNode pre = null;
        while (newhead != null)
        {
            ListNode tmp = newhead.next;
            newhead.next = pre;
            pre = newhead;
            newhead = tmp;
        }
        ListNode p = pre;
        while (p != null)
        {
            if (head.val != p.val) return false;
            head = head.next;
            p = p.next;
        }
        return true;
    }

    public bool IsPalindrome(ListNode head)
    {
        if (head == null || head.next == null) return true;
        ListNode slow = head;
        ListNode fast = head;
        ListNode pre = head;
        ListNode prepre = null;
        while (fast != null && fast.next != null)
        {
            pre = slow;
            slow = slow.next;
            fast = fast.next.next;
            pre.next = prepre;
            prepre = pre;
        }
        if (fast != null)
            slow = slow.next;
        while (slow != null)
        {
            if (slow.val != pre.val) return false;
            slow = slow.next;
            pre = pre.next;
        }
        return true;
    }
}