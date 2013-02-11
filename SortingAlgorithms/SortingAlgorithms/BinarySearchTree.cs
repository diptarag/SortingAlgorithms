using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithms
{
    /// <summary>
    /// Class to represent a tree node
    /// </summary>
    class Node
    {
        public double Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(double data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    /// <summary>
    /// Class To represent a Binary Search Tree
    /// </summary>
    public class BinarySearchTree
    {
        #region [Members]
        Node root;
        #endregion

        #region [Constructor]
        public BinarySearchTree()
        {
            root = null;            
        }
        #endregion

        #region [Public Methods]
        /// <summary>
        /// Insert a value in the Binary Search Tree
        /// </summary>
        /// <param name="value">Value to insert</param>
        public void Insert(double value)
        {
            Node node = new Node(value);
            if (root == null)
                root = node;
            else
                InsertAndBuildBST(root, node);
        }

        /// <summary>
        /// Traverse the Binary Search Tree in Pre-Order fashion
        /// </summary>
        /// <returns>The traversal in sequential order</returns>
        public List<double> Traverse()
        {
            List<double> sortedList = new List<double>();
            PreOrderTraversal(sortedList, root);
            return sortedList;
        }
        #endregion        

        #region [Private Helpers]
        /// <summary>
        /// Insert a value at it's correct position
        /// </summary>
        /// <param name="rootNode">Node to start search</param>
        /// <param name="insertNode">Node to insert</param>
        private void InsertAndBuildBST(Node rootNode, Node insertNode)
        {
            if (rootNode.Data > insertNode.Data)
            {
                if (rootNode.Left == null)
                    rootNode.Left = insertNode;
                else
                    InsertAndBuildBST(rootNode.Left, insertNode);
            }
            else if (rootNode.Data < insertNode.Data)
            {
                if (rootNode.Right == null)
                    rootNode.Right = insertNode;
                else
                    InsertAndBuildBST(rootNode.Right, insertNode);
            }
        }

        /// <summary>
        /// Pre order binasry tree traversal method
        /// </summary>
        /// <param name="sortedList">List where sequence will be stored</param>
        /// <param name="node">Node to start traversal</param>
        private void PreOrderTraversal(List<double> sortedList, Node node)
        {
            if (node != null)
            {
                PreOrderTraversal(sortedList, node.Left);
                sortedList.Add(node.Data);
                PreOrderTraversal(sortedList, node.Right);
            }
        }
        #endregion        
    }
}
