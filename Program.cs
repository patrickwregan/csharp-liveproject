using System;

namespace narynode3
{
    class Program
    {
        static void Main(string[] args)
        {
            NaryNode<string> node = new NaryNode<string>("Root");
            node.AddChild(new NaryNode<string>("A"));
            node.AddChild(new NaryNode<string>("B"));
            node.AddChild(new NaryNode<string>("C"));
            node.Children[0].AddChild(new NaryNode<string>("D"));
            node.Children[0].AddChild(new NaryNode<string>("E"));
            node.Children[2].AddChild(new NaryNode<string>("F"));
            node.Children[0].Children[0].AddChild(new NaryNode<string>("G"));
            node.Children[2].Children[0].AddChild(new NaryNode<string>("H"));
            node.Children[2].Children[0].AddChild(new NaryNode<string>("I"));

            Console.WriteLine(node.ToString());
            NaryNode<string>.FindValue(node, "Root");
            NaryNode<string>.FindValue(node, "A");
            NaryNode<string>.FindValue(node, "B");
            NaryNode<string>.FindValue(node, "C");
            NaryNode<string>.FindValue(node, "D");
            NaryNode<string>.FindValue(node, "E");
            NaryNode<string>.FindValue(node, "F");
            NaryNode<string>.FindValue(node, "Q");
        }
    }
}
