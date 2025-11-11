using System;
using System.Collections.Generic;

namespace MuniServicesApp.DataStructures
{
    public class AVLTree<T> where T : IComparable<T>
    {
        private AVLNode<T> root;
        private int count;

        public int Count => count;

        public AVLTree()
        {
            root = null;
            count = 0;
        }

        public void Insert(T data)
        {
            root = InsertRecursive(root, data);
            count++;
        }

        private AVLNode<T> InsertRecursive(AVLNode<T> node, T data)
        {
            if (node == null)
            {
                return new AVLNode<T>(data);
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
            else
            {
                return node;
            }

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            int balance = GetBalance(node);

            if (balance > 1 && data.CompareTo(node.Left.Data) < 0)
            {
                return RotateRight(node);
            }

            if (balance < -1 && data.CompareTo(node.Right.Data) > 0)
            {
                return RotateLeft(node);
            }

            if (balance > 1 && data.CompareTo(node.Left.Data) > 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && data.CompareTo(node.Right.Data) < 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public bool Delete(T data)
        {
            int initialCount = count;
            root = DeleteRecursive(root, data);
            return count < initialCount;
        }

        private AVLNode<T> DeleteRecursive(AVLNode<T> node, T data)
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

                if (node.Left == null || node.Right == null)
                {
                    AVLNode<T> temp = node.Left ?? node.Right;
                    if (temp == null)
                    {
                        return null;
                    }
                    else
                    {
                        return temp;
                    }
                }
                else
                {
                    AVLNode<T> temp = FindMin(node.Right);
                    node.Data = temp.Data;
                    node.Right = DeleteRecursive(node.Right, temp.Data);
                    count++;
                }
            }

            if (node == null)
            {
                return null;
            }

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            int balance = GetBalance(node);

            if (balance > 1 && GetBalance(node.Left) >= 0)
            {
                return RotateRight(node);
            }

            if (balance > 1 && GetBalance(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && GetBalance(node.Right) <= 0)
            {
                return RotateLeft(node);
            }

            if (balance < -1 && GetBalance(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        private AVLNode<T> FindMin(AVLNode<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        public T Search(T data)
        {
            return SearchRecursive(root, data);
        }

        private T SearchRecursive(AVLNode<T> node, T data)
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

        private int GetHeight(AVLNode<T> node)
        {
            return node?.Height ?? 0;
        }

        private int GetBalance(AVLNode<T> node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        private AVLNode<T> RotateRight(AVLNode<T> y)
        {
            AVLNode<T> x = y.Left;
            AVLNode<T> T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        private AVLNode<T> RotateLeft(AVLNode<T> x)
        {
            AVLNode<T> y = x.Right;
            AVLNode<T> T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }

        public List<T> InOrderTraversal()
        {
            List<T> result = new List<T>();
            InOrderRecursive(root, result);
            return result;
        }

        private void InOrderRecursive(AVLNode<T> node, List<T> result)
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

    internal class AVLNode<T>
    {
        public T Data { get; set; }
        public AVLNode<T> Left { get; set; }
        public AVLNode<T> Right { get; set; }
        public int Height { get; set; }

        public AVLNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
            Height = 1;
        }
    }
}
