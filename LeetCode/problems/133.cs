using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _133 : BaseClass
    {
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        Node[] nodes;
        public Node CloneGraph(Node node)
        {
            nodes = new Node[100];
            return dfs(node);
        }

        private Node dfs(Node node)
        {
            var newNode = new Node(node.val);
            nodes[node.val] = newNode;
            foreach(var child in node.neighbors)
            {
                var newChild = nodes[child.val];
                if (newChild == null)
                    newNode.neighbors.Add(dfs(child));
                else
                    newNode.neighbors.Add(newChild);
            }
            return newNode;
        }

        public override void Run()
        {
        }
    }
}
