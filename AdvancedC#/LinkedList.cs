using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedC_
{
    public class LinkedList
    {

        private Node? head;
        public int count{ get; private set; }
        public void Add(int value)
        {
            Node newNode = new Node { Value = value };
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            count++;
        }
        // in the Nested class, we can use the Node class to represent each element in the linked list. The Node class has two properties: Value, which stores the value of the node, and Next, which points to the next node in the list. The LinkedList class has a private field head that points to the first node in the list, and a public property count that keeps track of the number of nodes in the list.
        /// <summary>
        /// Adds a new node with the specified value to the end of the list.
        /// </summary>
        /// <param name="value">The value to add.</param>
        /// Why the Class Node is private? The Node class is private
        //because it is only used internally by the LinkedList class. 
        //It is not intended to be used outside of the LinkedList class,
        //so it is marked as private to prevent external access.
        // This encapsulation helps to maintain the integrity of the linked list and ensures that the nodes are only manipulated through the LinkedList class's public methods.
        private class Node { 
        public int Value;
            public Node? Next;
        }
    }
}
