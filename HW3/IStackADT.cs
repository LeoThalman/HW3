using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HW3
{
    /** C# Interface defining a Stack. */
    interface IStackADT
    {
        /*
         * push an item onto top of stack. Pushing an object that doesn't exist shold
         * result in an error. Pushing an object that is not an item should result in an
         * error. This operation returns a reference to the item pushed so than an anonymous
         * object can be pushed and then used.
         * @param newItem The object to push onto the top of the stack. Should not be null
         * @return A reference to the object that was pushed, or null if newNull == null
         */
        Object Push(Object newItem);

        /**
         * Remove and return an item from the top of the stack. This operation should result
         * in an error if the stack is empty. Returns a reference to the item removed.
         * @return A reference that was popped (and removed) from the stack or null if
         *          the stack is empty
         */
        Object Pop();
    }
}
