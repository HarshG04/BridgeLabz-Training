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
    public ListNode DeleteDuplicates(ListNode head) {
        if(head==null) return head;
        // return RemoveDuplicates(head);
        return RemoveDuplicates1(head);
        
    }
    public ListNode RemoveDuplicates(ListNode head){
        ListNode temp = head;
        ListNode pointer = head;
        while(temp!=null && temp.next!=null){
            while(temp.next!=null && temp.val==temp.next.val) temp=temp.next;
            if(temp.next==null) break;
            pointer.next = temp.next;
            pointer = pointer.next;
            temp = temp.next;
        }
        pointer.next = null;
        return head;
    }
    public ListNode RemoveDuplicates1(ListNode head){
        ListNode temp = head;
        while(head!=null && head.next!=null){
            if(head.val == head.next.val){
                head.next = head.next.next;
            }else{
                head = head.next;
            }
        }
        return temp;
    }
}