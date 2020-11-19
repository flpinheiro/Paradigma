using System;
using System.Collections.Generic;
using System.Linq;

namespace Paradigma
{
    class Tree
    {
        public Tree(in int node, List<int> right, List<int> left)
        {
            Node = node;
            if (right != null && right.Count != 0)
            {
                var rightNode = right.First();
                right.RemoveAt(0);
                Right = new Tree(rightNode, right, null);
            }
            if (left != null && left.Count != 0)
            {
                var leftNode = left.First();
                left.RemoveAt(0);
                Left = new Tree(leftNode, null, left);
            }
        }

        public int Node { get; }
        public Tree Left { get; set; }
        public Tree Right { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Paradigma!");

            var intArray = new[] { 3, 2, 1, 6, 0, 5 };
            var maior = intArray[0];
            var maiorIndex = 0;

            for (var i = 0; i < intArray.Length; i++)
            {
                if (maior < intArray[i])
                {
                    maior = intArray[i];
                    maiorIndex = i;
                }
            }

            Console.WriteLine($"maior: {maior}, Index: {maiorIndex}");

            var right = intArray.Skip(0).Take(maiorIndex).ToList();
            right.Sort();
            right.Reverse();

            var left = intArray.Skip(maiorIndex + 1).Take(intArray.Length - maiorIndex).ToList();
            left.Sort();
            left.Reverse();

            var tree = new Tree(maior, right, left);
        }
    }
}
