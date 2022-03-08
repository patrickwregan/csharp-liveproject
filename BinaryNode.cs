using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarynode3
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
            return ToString("");

            //return Value.ToString() + ": " + (LeftChild?.Value.ToString() ?? "null") + " " + (RightChild?.Value.ToString() ?? "null");
        }

        public string ToString(string spaces)
        {
            string result = spaces + Value + ":\n";

            if(LeftChild != null || RightChild != null)
            {
                if(LeftChild == null)
                {
                    
                    result += spaces + "    null" + "\n";
                }

                else
                {
                    
                    result += LeftChild.ToString(spaces + "    ");
                }

                if(RightChild == null)
                {
                    result += spaces + "    null" + "\n";
                }
                else
                {
                    result += RightChild.ToString(spaces + "    ");
                }
            }
            return result;
        }

        public BinaryNode<T> FindNode(T val)
        {
            //Console.WriteLine(Value.ToString()) ;
            //BinaryNode<T> node;
            if (EqualityComparer<T>.Default.Equals(Value, val))
            {
                return this;
            }

            if(LeftChild != null)
            {
                // recursive call either finds something (returns node or returns null
                // if it does find something, we want to return that value but
                // if it does not find anything we want to make sure to continue with 
                // the right node so child if != null then return node (end recursive calls) otherwise
                // continue to next if statement which does the same for RightNode
                // I think this is slightly different than when you send the node as a 
                // parameter of the function.
                BinaryNode<T> node = LeftChild.FindNode(val);
                if(node != null)
                {
                    return node;
                }
            }
            if(RightChild != null)
            {
                BinaryNode<T> node = RightChild.FindNode(val);
                if(node != null)
                {
                    return node;
                }
            }
            return null;                 
        }


        internal List<BinaryNode<T>> TraversePreorder()
        {
            List<BinaryNode<T>> result = new List<BinaryNode<T>>();

            // Add this node to the traversal.
            result.Add(this);

            // Add the child subtrees.
            if (LeftChild != null)
            {
                result.AddRange(LeftChild.TraversePreorder());
               
            }
            if (RightChild != null)
            {
                result.AddRange(RightChild.TraversePreorder());
                
                
            }
            return result;
        }
        
        internal List<BinaryNode<T>> TraverseInorder()
        {
            List<BinaryNode<T>> result = new List<BinaryNode<T>>();

            // Add the left subtree.
            if (LeftChild != null)
            {
                result.AddRange(LeftChild.TraverseInorder());

            }

            // Add this node.
            result.Add(this);

            // Add the right subtree.
            if (RightChild != null)
            {
                result.AddRange(RightChild.TraverseInorder());
            }
            return result;
        }
        
        internal List<BinaryNode<T>> TraversePostorder()
        {
            List<BinaryNode<T>> result = new List<BinaryNode<T>>();

            // Add the child subtrees.
            if (LeftChild != null)
            {
                result.AddRange(LeftChild.TraversePostorder());
            }
            if (RightChild != null)
            {
                result.AddRange(RightChild.TraversePostorder());
            }

            // Add this node.
            result.Add(this);
            return result;
        }

        
        internal List<BinaryNode<T>> TraverseBreadthFirst()
        {
            List<BinaryNode<T>> result = new List<BinaryNode<T>>();
            Queue<BinaryNode<T>> queue = new Queue<BinaryNode<T>>();

            // Start with the top node in the queue.
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                // Remove the top node from the queue and
                // add it to the result list.
                BinaryNode<T> node = queue.Dequeue();
                result.Add(node);

                // Add the node's children to the queue.
                if (node.LeftChild != null)
                {
                    queue.Enqueue(node.LeftChild);
                    
                }
                if (node.RightChild != null)
                {
                    queue.Enqueue(node.RightChild);
                    
                }
            }
            return result;
        }
        
        public static void FindValue(BinaryNode<T> startingNode, T target)
        {
            BinaryNode<T> node = startingNode.FindNode(target);
            if(node == null)
            {
                Console.WriteLine(target.ToString() + " not found.");
            }
            else
            {
                Console.WriteLine(target.ToString() + " found.");
            }
        }

    }
}
