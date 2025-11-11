using System;
using System.Collections.Generic;

namespace MuniServicesApp.DataStructures
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private BSTNode<T> root;
        private int count;

        public int Count => count;

        public BinarySearchTree()
        {
            root = null;
            count = 0;
        }

        public void Insert(T data)
        {
            root = InsertRecursive(root, data);
            count++;
        }

        private BSTNode<T> InsertRecursive(BSTNode<T> node, T data)
        {
            if (node == null)
            {
                return new BSTNode<T>(data);
            }

            int comparison = data.CompareTo(node.Data);
            if (comparison < 0)
            {
                node.Left = InsertRecursive(node.Left, data);
            }
            else if (comparison > 0)
            {
                node.Right = InsertRecursive(node.Right, data);
            }

            return node;
        }

        public T Search(T data)
        {
            return SearchRecursive(root, data);
        }

        private T SearchRecursive(BSTNode<T> node, T data)
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

        public bool Delete(T data)
        {
            int initialCount = count;
            root = DeleteRecursive(root, data);
            return count < initialCount;
        }

        private BSTNode<T> DeleteRecursive(BSTNode<T> node, T data)
        {
            if (node == null)
            {
                return null;
            }

            int comparison = data.CompareTo(node.Data);
            if (comparison < 0)
            {
                node.Left = DeleteRecursive(node.Left, data);
            }
            else if (comparison > 0)
            {
                node.Right = DeleteRecursive(node.Right, data);
            }
            else
            {
                count--;

                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }

                BSTNode<T> minNode = FindMin(node.Right);
                node.Data = minNode.Data;
                node.Right = DeleteRecursive(node.Right, minNode.Data);
                count++;
            }

            return node;
        }

        private BSTNode<T> FindMin(BSTNode<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        public List<T> InOrderTraversal()
        {
            List<T> result = new List<T>();
            InOrderRecursive(root, result);
            return result;
        }

        private void InOrderRecursive(BSTNode<T> node, List<T> result)
        {
            if (node != null)
            {
                InOrderRecursive(node.Left, result);
                result.Add(node.Data);
                InOrderRecursive(node.Right, result);
            }
        }

        public List<T> PreOrderTraversal()
        {
            List<T> result = new List<T>();
            PreOrderRecursive(root, result);
            return result;
        }

        private void PreOrderRecursive(BSTNode<T> node, List<T> result)
        {
            if (node != null)
            {
                result.Add(node.Data);
                PreOrderRecursive(node.Left, result);
                PreOrderRecursive(node.Right, result);
            }
        }

        public List<T> PostOrderTraversal()
        {
            List<T> result = new List<T>();
            PostOrderRecursive(root, result);
            return result;
        }

        private void PostOrderRecursive(BSTNode<T> node, List<T> result)
        {
            if (node != null)
            {
                PostOrderRecursive(node.Left, result);
                PostOrderRecursive(node.Right, result);
                result.Add(node.Data);
            }
        }

        public void Clear()
        {
            root = null;
            count = 0;
        }
    }

    internal class BSTNode<T>
    {
        public T Data { get; set; }
        public BSTNode<T> Left { get; set; }
        public BSTNode<T> Right { get; set; }

        public BSTNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
