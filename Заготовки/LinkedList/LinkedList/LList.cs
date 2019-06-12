using System.Text;

namespace LinkedList
{
    public class LList<T>
    {
        private class Node
        {
            public T value;
            public Node next;
        }

        private Node _head;

        public void Enqueue(T val)
        {
            if (_head == null)
            {
                _head = new Node { value = val };
                return;
            }

            var temp = _head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = new Node { value = val };
        }

        public void Push(T val)
        {
            if (_head == null)
            {
                _head = new Node { value = val };
                return;
            }

            var temp = _head;
            _head = new Node { value = val, next = temp };
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            PrintToStringBuilder(_head, str, ", ");

            return str.ToString();
        }

        private void PrintToStringBuilder(Node currentNode, StringBuilder str, string divider)
        {
            if (currentNode == null)
                return;

            str.Append(currentNode.value + divider);
            PrintToStringBuilder(currentNode.next, str, divider);
        }
    }
}
