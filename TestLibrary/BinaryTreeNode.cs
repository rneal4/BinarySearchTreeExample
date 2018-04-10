namespace TestLibrary
{
    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode() : base() { }
        public BinaryTreeNode(T data) : base(data, null) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            Value = data;
            NodeList<T> children = new NodeList<T>(2)
            {
                [0] = left,
                [1] = right
            };

            Neighbors = children;
        }

        public BinaryTreeNode<T> Left
        {
            get => Neighbors == null ? null : (BinaryTreeNode<T>)Neighbors[0];
            set
            {
                if (Neighbors == null)
                    Neighbors = new NodeList<T>(2);

                Neighbors[0] = value;
            }
        }
        public BinaryTreeNode<T> Right
        {
            get => Neighbors == null ? null : (BinaryTreeNode<T>)Neighbors[1];
            set
            {
                if (Neighbors == null)
                    Neighbors = new NodeList<T>(2);

                Neighbors[1] = value;
            }
        }

    }
}
