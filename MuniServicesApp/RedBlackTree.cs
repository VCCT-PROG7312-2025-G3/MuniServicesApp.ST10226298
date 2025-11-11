using System;
using System.Collections.Generic;

namespace MuniServicesApp.DataStructures
{
    public class RedBlackTree<T> where T : IComparable<T>
    {
        private RBNode<T> root;
        private int count;

        public int Count => count;

        public RedBlackTree()
        {
            root = null;
            count = 0;
        }

        public void Insert(T data)
        {
            RBNode<T> newNode = new RBNode<T>(data);
            root = BSTInsert(root, newNode);
            FixInsert(newNode);
            count++;
        }

        private RBNode<T> BSTInsert(RBNode<T> root, RBNode<T> newNode)
        {
            if (root == null)
            {
                return newNode;
            }

            if (newNode.Data.CompareTo(root.Data) < 0)
            {
                root.Left = BSTInsert(root.Left, newNode);
                root.Left.Parent = root;
            }
            else if (newNode.Data.CompareTo(root.Data) > 0)
            {
                root.Right = BSTInsert(root.Right, newNode);
                root.Right.Parent = root;
            }

            return root;
        }

        private void FixInsert(RBNode<T> node)
        {
            while (node != root && node.Parent != null && node.Parent.Color == NodeColor.Red)
            {
                if (node.Parent.Parent == null)
                    break;
                    
                if (node.Parent == node.Parent.Parent.Left)
                {
                    RBNode<T> uncle = node.Parent.Parent.Right;

                    if (uncle != null && uncle.Color == NodeColor.Red)
                    {
                        node.Parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Right)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }

                        node.Parent.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        RotateRight(node.Parent.Parent);
                    }
                }
                else
                {
                    RBNode<T> uncle = node.Parent.Parent.Left;

                    if (uncle != null && uncle.Color == NodeColor.Red)
                    {
                        node.Parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }

                        node.Parent.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }

            root.Color = NodeColor.Black;
        }

        private void RotateLeft(RBNode<T> node)
        {
            RBNode<T> rightChild = node.Right;
            node.Right = rightChild.Left;

            if (rightChild.Left != null)
            {
                rightChild.Left.Parent = node;
            }

            rightChild.Parent = node.Parent;

            if (node.Parent == null)
            {
                root = rightChild;
            }
            else if (node == node.Parent.Left)
            {
                node.Parent.Left = rightChild;
            }
            else
            {
                node.Parent.Right = rightChild;
            }

            rightChild.Left = node;
            node.Parent = rightChild;
        }

        private void RotateRight(RBNode<T> node)
        {
            RBNode<T> leftChild = node.Left;
            node.Left = leftChild.Right;

            if (leftChild.Right != null)
            {
                leftChild.Right.Parent = node;
            }

            leftChild.Parent = node.Parent;

            if (node.Parent == null)
            {
                root = leftChild;
            }
            else if (node == node.Parent.Right)
            {
                node.Parent.Right = leftChild;
            }
            else
            {
                node.Parent.Left = leftChild;
            }

            leftChild.Right = node;
            node.Parent = leftChild;
        }

        public T Search(T data)
        {
            return SearchRecursive(root, data);
        }

        private T SearchRecursive(RBNode<T> node, T data)
        {
            if (node == null)
            {
                return default(T);
            }

            int comparison = data.CompareTo(node.Data);
            if (comparison == 0)
            {
                return node.Data;
            }
            else if (comparison < 0)
            {
                return SearchRecursive(node.Left, data);
            }
            else
            {
                return SearchRecursive(node.Right, data);
            }
        }

        public List<T> InOrderTraversal()
        {
            List<T> result = new List<T>();
            InOrderRecursive(root, result);
            return result;
        }

        private void InOrderRecursive(RBNode<T> node, List<T> result)
        {
            if (node != null)
            {
                InOrderRecursive(node.Left, result);
                result.Add(node.Data);
                InOrderRecursive(node.Right, result);
            }
        }

        public void Clear()
        {
            root = null;
            count = 0;
        }
    }

    internal enum NodeColor
    {
        Red,
        Black
    }

    internal class RBNode<T>
    {
        public T Data { get; set; }
        public RBNode<T> Left { get; set; }
        public RBNode<T> Right { get; set; }
        public RBNode<T> Parent { get; set; }
        public NodeColor Color { get; set; }

        public RBNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
            Parent = null;
            Color = NodeColor.Red;
        }
    }
}
