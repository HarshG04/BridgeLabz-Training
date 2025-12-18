/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode() {}
 *     public ListNode(int val) { this.val = val; }
 *     public ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        return Merge(list1, list2);
    }

    public ListNode Merge(ListNode node1, ListNode node2)
    {
        if (node1 == null && node2 == null) return null;

        ListNode head = new ListNode();
        ListNode node = head;

        while (node1 != null && node2 != null)
        {
            if (node1.val < node2.val)
            {
                node.next = node1;
                node1 = node1.next;
            }
            else
            {
                node.next = node2;
                node2 = node2.next;
            }
            node = node.next;
        }

        if (node1 != null) node.next = node1;
        if (node2 != null) node.next = node2;

        return head.next;
    }
}
