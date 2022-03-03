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

    }

}
