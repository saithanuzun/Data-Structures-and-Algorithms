using System.Collections;

class Node<T>
{ 
   public Node<T>? Next;
   public T? Data;
}

interface IStack<T> : IEnumerable<T>
{
    public int Count { get; } 
    void Push(T data);
    T Pop();
    T Peek();
    void Clear();
}
class Stack<T> : IStack<T>
{
    private Node<T> _head;
    private Node<T> Head { get => _head; set => _head=value; }
    public int Count
    {
        get
        {
            int _count = 0;
            Node<T> iterator = new();
            iterator = Head;
            while (iterator is not null)
            {
                _count ++;
                iterator = iterator.Next;
            }
            return _count;
        }
    }

    public void Push(T data)
    {
        Node<T> myNode = new() { Next = null, Data = data };
        if (Head is null)
            Head = myNode;
        else
        {
            myNode.Next = Head;
            Head = myNode;
        }
    }

    public T Pop()
    {
        T data = Head.Data;
        Head = Head.Next;
        return data;
    }

    public T Peek()
    {
        return Head.Data;
    }

    public void Clear()
    {
        Node<T> newHead = new();
        Head = newHead;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> iter = Head;
        while (iter is not null)
        {
            yield return iter.Data;
            iter = iter.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Stack2<T> : IStack<T>
{
    private int _size;
    private Node<T> _head;
    private Node<T> Head { get => _head; set => _head = value; }
    private Node<T> _current;
    private Node<T> Current
    {
        get
        {
            Current = Head;
            for (int i = 1; i<_size ; i++)
            {
                Current = _current.Next;
            } 
            return _current;
        }
        set => _current = value;
    }
    
    public int Count => _size;
    public void Push(T data)
    {
        Node<T> myNode = new() {Next = null , Data = data };
        
        if (Head is null)
        {
            Head = myNode;
            Current = Head;
        }
        else
            Current.Next = myNode;
        
        _size += 1;
    }
    
    public T Pop()
    {
        _size -= 1;
        return Current.Data;
    }
    
    public T Peek()
    {
        return Current.Data;
    }

    public void Clear()
    {
        Head = null;
        _size = 0;
    }
    public IEnumerator<T> GetEnumerator()
    {
        Node<T> iter = Head;
        while (iter is not null)
        {
            yield return iter.Data;
            iter = iter.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    public static void Main(string[] args)
    {
        //new Stack() or Stack2()
        IStack<string> myStack = new Stack<string>();
        
        myStack.Push("hello");
        myStack.Push("world");
        
        Console.WriteLine(myStack.Count);
        Console.WriteLine(myStack.Peek());
        myStack.Pop();
        Console.WriteLine(myStack.Peek());
        myStack.Clear();
        Console.WriteLine("clear");
        myStack.Push("hello");
        myStack.Push("again");
        Console.WriteLine(myStack.Peek());
    }
}