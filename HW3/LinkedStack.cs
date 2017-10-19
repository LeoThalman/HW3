using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    /**
     * A singly linked stack.
     */ 
    class LinkedStack : IStackADT
    {
        private Node top;

        public LinkedStack()
        {
            top = null; //empty stack
        }

        public Object Push(Object newItem)
        {
            if (newItem == null)
            {
            }
            //if not null add to list, else return null
            else
            {
                Node newNode = new Node(newItem, top);
                top = newNode;
            }
            return newItem;
        }

        //if Stack is empty return null, else pop top item on stack
        public Object Pop()
        {
            Object rItem = null;
            if(IsEmpty() )
            {
            }
            else
            {
                rItem = top.data;
                top = top.next;
            }
            return rItem;
        }

        //if stack empty return null, else return top item
        public Object Peek()
        {
            Object rItem = null;            
            if (IsEmpty() )
            {
            }
            else
            {
                rItem = top.data;
            }
            return rItem;
        }

        public Boolean IsEmpty()
        {
            return top == null;
        }

        public void Clear()
        {
            top = null;
        }
    }
}
