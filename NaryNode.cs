using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace narynode1
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
            string result = "";
            foreach(var v in Children)
            {
                result += v.ToString() + " ";
            }
            return Value.ToString() + ": " + result;
        }



    }


}
