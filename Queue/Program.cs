class Node<T>
{ 
   public Node<T>? Next;
   public T? Data;
}

interface IQueue<T>
{
    public int Count { get; } 
    void Push(T data);
    T Pop();
    T Peek();
    void Clear();
}

class Queue<T> : IQueue<T>
{
    private Node<T> head,current;
    private Node<T> Head { get => head; set => head = value; }

    private int size;
    public int Count => size;
    
    public void Push(T data)
    {
        Node<T> myNode = new() { Data = data };
        if (Head is null)
            head = myNode;
        else
        {
            Node<T> iter = new();
            iter = Head;
            while (iter.Next is not null)
            {
                iter = iter.Next;
            }
            iter.Next = myNode;
        }
        size++;
    }

    public T Pop()
    {
        T data = Head.Data;
        Head = Head.Next;
        size--;
        return data;
    }

    public T Peek()
    {
        return Head.Data;
    }

    public void Clear()
    {
        Head = null;
        size = 0;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        IQueue<string> myQueue = new Queue<string>();
        myQueue.Push("Hello");
        Console.WriteLine("count:"+myQueue.Count); //output 1
        myQueue.Push("World");
        Console.WriteLine(myQueue.Peek());//output hello
        myQueue.Clear();
        myQueue.Push("Hello");
        myQueue.Push("World");
        myQueue.Push("Again");
        Console.WriteLine("Count:"+myQueue.Count);
        Console.WriteLine(myQueue.Pop());//output hello
        Console.WriteLine(myQueue.Peek());// output world
        myQueue.Pop();
        Console.WriteLine(myQueue.Peek());//output again
    }
}