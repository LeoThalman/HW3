using System;

/* 
 * A single linked node class.
 */


public class Node
{
    public Object data; //The data being held
    public Node next;  // the next node in the list

	public Node()
	{
        data = null;
        next = null;
	}

    public Node(Object data, Node next)
    {
        this.data = data;
        this.next
    }
}
