/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head) {
        if(head==null) return null;
        // return ReverseRec(head,null);
        return ReverseItr(head);
    }
    public ListNode ReverseRec(ListNode curr,ListNode prev){
        if(curr==null) return prev;

        ListNode node = ReverseRec(curr.next,curr);
        curr.next = prev;
        return node;
    }

    public ListNode ReverseItr(ListNode node){
        ListNode prev = null;
        ListNode curr = node;
        while(curr!=null){
            ListNode temp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = temp;
        }
        return prev;
    }
}