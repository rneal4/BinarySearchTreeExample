namespace TestLibrary
{
    public class Node<T>
    {
        public Node() { }
        public Node(T value) : this(value, null) { }
        public Node(T value, NodeList<T> neighbors)
        {
            Value = value;
            Neighbors = neighbors;
        }

        public T Value { get; set; }

        protected NodeList<T> Neighbors { get; set; } = null;
    }
}
