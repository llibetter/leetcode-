  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }
/*
143. 重排链表
给定一个单链表 L：L0→L1→…→Ln-1→Ln ，
将其重新排列后变为： L0→Ln→L1→Ln-1→L2→Ln-2→…

你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。

示例 1:

给定链表 1->2->3->4, 重新排列为 1->4->2->3.
示例 2:

给定链表 1->2->3->4->5, 重新排列为 1->5->2->4->3.
*/


//快慢指针找中点，再分割，逆序，连接，一气呵成，老板看了直呼内行😂😂😂😂
public class Solution {
    public void ReorderList(ListNode head) {
        if(head==null||head.next==null) return;
        ListNode fast=head;
        ListNode slow=head;
        while(fast!=null&&fast.next!=null&&fast.next.next!=null)
        {
            slow=slow.next;
            fast=fast.next.next;
        }
        ListNode newHead=slow.next;
        slow.next=null;
        
        ListNode pre=null;
        while(newHead!=null)
        {
            ListNode tmp=newHead.next;
            newHead.next=pre;
            pre=newHead;
            newHead=tmp;
        }

        ListNode p2=head;
        ListNode p3=pre;
        while(p2!=null)
        {
            ListNode tmp1=p2.next;
            ListNode tmp2=p3.next;
            p2.next=p3;
            p3.next=tmp1;
            p2=tmp1;
            p3=tmp2;
            if(p3==null) break;
        }
    }
}