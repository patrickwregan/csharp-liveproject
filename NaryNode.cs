using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace narynode3
{
    class NaryNode<T>
    {
        T Value { get; set; }
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
