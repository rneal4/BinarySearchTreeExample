namespace TestLibrary
{

    public class BinaryTree<T>
    {
        public BinaryTree()
        {
            Root = null;
        }

        public BinaryTree(BinaryTreeNode<T> root)
        {
            Root = root;
        }

        public virtual void Clear()
        {
            Root = null;
        }

        public BinaryTreeNode<T> Root { get; set; }
    }
}
