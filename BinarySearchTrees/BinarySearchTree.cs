using System;
using System.Collections;
using System.Collections.Generic;

namespace TestLibrary
{
    public class BinarySearchTree<T> : BinaryTree<T> , IEnumerable<T>
    {
        public BinarySearchTree() : base() { }

        private Comparer<T> comparer;
        public int Count { get; private set; }

        public bool Contains(T data)
        {
            BinaryTreeNode<T> current = Root;
            
            while (current != null)
            {
                int result = comparer.Compare(current.Value, data);
                if (result == 0)
                    return true;
                else if (result > 0)
                    current = current.Left;
                else if (result < 0)
                    current = current.Right;
            }

            return false;
        }

        public virtual void Add(T data)
        {
            BinaryTreeNode<T> current = Root, parent = null;

            while (current != null)
            {
                int result = comparer.Compare(current.Value, data);
                if (result == 0)
                    throw new ArgumentException($"The argument {nameof(T)} already exists in this {nameof(BinarySearchTree<T>)}", nameof(data));

                parent = current;
                current = result > 0 ? current.Left : current.Right;
            }


            BinaryTreeNode<T> n = new BinaryTreeNode<T>(data);
            
            if (parent == null)
            {
                Root = n;
            }
            else
            {
                if (comparer.Compare(parent.Value, data) > 0)
                    parent.Left = n;
                else
                    parent.Right = n;                
            }


            Count++;
        }

        public bool Remove(T data)
        {
            if (Root == null)
                return false;

            BinaryTreeNode<T> current = Root, parent = null;
            int result = comparer.Compare(current.Value, data);

            while (result != 0)
            {
                parent = current;
                current = result > 0 ? current.Left : current.Right;

                if (current == null)
                    return false;

                result = comparer.Compare(current.Value, data);
            }


            if (current.Right == null)
            {
                if (parent == null)
                {
                    Root = current.Left;
                }
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                        parent.Left = current.Left;
                    else if (result < 0)
                        parent.Right = current.Left;
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    Root = current.Right;
                }
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                        parent.Left = current.Right;
                    else if (result < 0)
                        parent.Right = current.Right;
                }
            }
            else
            {
                BinaryTreeNode<T> leftMost = current.Right.Left, leftMostParent = current.Right;

                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;

                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                {
                    Root = leftMost;
                }
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                        parent.Left = leftMost;
                    else if (result < 0)
                        parent.Right = leftMost;
                }
            }

            Count--;

            return true;
        }

        public void CopyTo(ref Array array, int index = 0, TraversalMethod traversal = TraversalMethod.Inorder)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator();
        }

        public struct Enumerator : IEnumerator<T>
        {
            public T Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }

    //public class testarea
    //{
    //    public void testmethod()
    //    {
    //        BinarySearchTree<int> vs = new BinarySearchTree<int>();
            
    //    }
    //}
}
