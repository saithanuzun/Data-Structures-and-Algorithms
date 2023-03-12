class Node<T>
{
  public Node<T> Next;
  public T Data;
}

class LinkedList<T>
{
    private Node<T> head;
    
    public void GetAllNodes()
    {
        Node<T> iterator = head;
        while (iterator is not null)
        {
            Console.WriteLine(iterator.Data);
            iterator = iterator.Next;
        }
    }

    public void Add(T data)
    {
        Node<T> myNode = new() { Data = data, Next = null };
        if (head is null)
            head = myNode;
        else
        {
            Node<T> iterator = head;
            while (iterator.Next is not null)
            {
                iterator = iterator.Next;
            }
            iterator.Next = myNode;
        }
    }
    
}

class Program
{ 
    public static void Main(string[] args)
    {
        LinkedList<string> myList = new();
        myList.Add("Hello");
        myList.Add("World");
      

        myList.GetAllNodes();
    }
}