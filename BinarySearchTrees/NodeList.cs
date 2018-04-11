using System.Collections.ObjectModel;

namespace TestLibrary
{
    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int InitialSize)
        {
            for (int i = 0; i < InitialSize; i++)
                Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value)
        {
            foreach (Node<T> node in Items)
            {
                if (node.Value.Equals(value))
                    return node;
            }

            return null;
        }
    }
}
