using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_node1
{
    class BinaryNode<T>
    {
        public T Value { get; set; }
        public BinaryNode<T> LeftChild;
        public BinaryNode<T> RightChild;
        public BinaryNode(T val)
        {
            Value = val;
            LeftChild = null;
            RightChild = null;
        }

        public void AddLeft(BinaryNode<T> child)
        {
            LeftChild = child;
        }

        public void AddRight(BinaryNode<T> child)
        {
            RightChild = child;
        }

        public override string ToString()
        {
            
            return Value.ToString() + ": " + (LeftChild?.Value.ToString() ?? "null") + " " + (RightChild?.Value.ToString() ?? "null");
        }

    }
}
