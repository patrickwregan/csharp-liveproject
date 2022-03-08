using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace narynode3
{
    class NaryNode<T>
    {
        public T Value { get; set; }
        public List<NaryNode<T>> Children;

        public NaryNode(T val)
        {
            Value = val;
            Children = new List<NaryNode<T>>();
        }

        public void AddChild(NaryNode<T> node)
        {
            Children.Add(node);
        }

        public override string ToString()
        {
            return ToString("   ");
        }

        public string ToString(string spaces)
        {
            string result = spaces + Value.ToString() + ":\n";

            foreach (NaryNode<T> child in Children)
                result += child.ToString(spaces + "  ");
            return result;
        }

        public NaryNode<T> FindNode(T val)
        {
            // check if val in this node
            if (EqualityComparer<T>.Default.Equals(Value, val))
            {
                return this;
            }
            foreach (NaryNode<T>child in Children)
            {
                NaryNode<T> node = child.FindNode(val);
                if(node != null)
                {
                    return node;
                }
            }
            return null;
        }

        internal List<NaryNode<T>> TraversePreorder()
        {
            List<NaryNode<T>> result = new List<NaryNode<T>>();

            // Add this node to the traversal.
            result.Add(this);

            // Add the children.
            foreach (NaryNode<T> child in Children)
            {
                result.AddRange(child.TraversePreorder());
            }

            return result;
        }

        internal List<NaryNode<T>> TraversePostorder()
        {
            List<NaryNode<T>> result = new List<NaryNode<T>>();

            // Add the children.
            foreach (NaryNode<T> child in Children)
            {
                result.AddRange(child.TraversePostorder());
            }

            // Add this node to the traversal.
            result.Add(this);
            return result;
        }

        internal List<NaryNode<T>> TraverseBreadthFirst()
        {
            List<NaryNode<T>> result = new List<NaryNode<T>>();
            Queue<NaryNode<T>> queue = new Queue<NaryNode<T>>();

            // Start with the top node in the queue.
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                // Remove the top node from the queue and
                // add it to the result list.
                NaryNode<T> node = queue.Dequeue();
                result.Add(node);

                // Add the node's children to the queue.
                foreach(NaryNode<T> child in node.Children)
                {
                    if(child != null)
                    {
                        queue.Enqueue(child);
                    }
                }
            }

            return result;
        }


        public static void FindValue(NaryNode<string> root, string target)
        {
            NaryNode<string> node = root.FindNode(target);
            if (node == null)
                Console.WriteLine(string.Format("Value {0} not found", target));
            else
                Console.WriteLine(string.Format("Found {0}", node.Value));
        }





    }



}
