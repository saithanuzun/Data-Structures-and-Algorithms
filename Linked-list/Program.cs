using System.Collections;
class Node<T>
{
  public Node<T> Next;
  public Node<T> Previous;
  public T Data;
}

interface ILinkedList<T> : IEnumerable<T>
{
    public int Count { get; }
    void Add(T data);
    void AddFirst(T data);
    void AddById(T data, int id);
    T Remove();
    T RemoveFirst();
    T RemoveById(int id);
    T Peek();
    T PeekFirst();
    T PeekById(int id);
    void Clear();
}

class LinkedList<T> : ILinkedList<T>
{
    private Node<T> head , tail;
    private int size;

    private Node<T> Head
    {
        get => head;
        set => head = value;
    }

    private Node<T> Tail
    {
        get
        {
            Tail = Head;
            while (tail.Next is not null)
            {
                tail = tail.Next;
            }
            return tail;
        }
        set => tail = value;
    }

    public int Count
    {
        get
        {
            Node<T> iter = Head;
            size = 0;
            while (iter is not null)
            {
                size++;
                iter = iter.Next;
            }
            return size;
        }
    }

    public void Add(T data)
    {
        Node<T> myNode = new() { Data = data };
        if (Head is null)
            Head = myNode;
        else
        {
            myNode.Previous = Tail;
            Tail.Next = myNode;
        }
    }

    public void AddFirst(T data)
    {
        Node<T> myNode = new() { Data = data };
        if (Head is null)
            Head = myNode;
        else
        {
            myNode.Next = Head;
            Head.Previous = myNode;
            Head = myNode;
        }
    }

    public void AddById(T data, int id)
    {
        Node<T> myNode = new() { Data = data };
        
        if(id > Count)
            return;
        
        Node<T> iter = Head;
        for (int i = 0; i < id; i++)
        { 
            iter = iter.Next;
        }
        myNode.Next = iter.Next;
        iter.Next = myNode;
        myNode.Previous = iter;
        myNode.Next.Previous = myNode;
    }

    public T Remove()
    {
        Node<T> myNode = Tail;
        Tail = Tail.Previous;
        Tail.Next = null;
        return myNode.Data;
    }

    public T RemoveFirst()
    {
        Node<T> myNode = Head;
        Head = Head.Next;
        Head.Previous = null;
        return Head.Data;
    }

    public T RemoveById(int id)
    {
        Node<T> iter = null;
        
        if (id > Count)
            return iter.Data;
        
        iter = Head;
        for (int i = 0; i < id; i++)
        {
            iter = iter.Next;                   
        }

        iter.Previous.Next = iter.Next;
        iter.Next.Previous = iter.Previous;

        return iter.Data;
    }

    public T Peek()
    {
        return Tail.Data;
    }

    public T PeekFirst()
    {
        return Head.Data;
    }

    public T PeekById(int id)
    {
        Node<T> iter = null;
        if (id > Count)
            return iter.Data;
        for (int i = 0; i < Count; i++)
        {
            iter = iter.Next;
        }
        return iter.Data;
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        size = 0;
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
        ILinkedList<string> myList = new LinkedList<string>();
        
        myList.Add("Hello");
        myList.Add("World");
        myList.AddFirst("from");
        Console.WriteLine(myList.Count);
        myList.AddById("Manchester",1);
        Console.WriteLine(myList.Count);
        Console.WriteLine(myList.RemoveById(1));
    }
}