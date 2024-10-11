using Assignment04;

class Program
{
    static void Main(string[] args)
    {
        // MyStack usage
        MyStack<int> intStack = new MyStack<int>();
        intStack.Push(10);
        intStack.Push(20);
        Console.WriteLine($"Stack count: {intStack.Count()}");
        Console.WriteLine($"Popped item: {intStack.Pop()}");
        Console.WriteLine($"Stack count after pop: {intStack.Count()}");

        // MyList usage
        MyList<string> myStringList = new MyList<string>();
        myStringList.Add("apple");
        myStringList.Add("banana");
        myStringList.InsertAt("cherry", 1);
        Console.WriteLine($"Item at index 1: {myStringList.Find(1)}");
        myStringList.Remove(0);
        Console.WriteLine($"Contains 'apple': {myStringList.Contains("apple")}");
        myStringList.Clear();
        Console.WriteLine($"List count after clear: {myStringList.Find(0)}"); // will throw exception

        // GenericRepository usage
        GenericRepository<Entity> repo = new GenericRepository<Entity>();
        Entity entity1 = new Entity { Id = 1 };
        Entity entity2 = new Entity { Id = 2 };
        repo.Add(entity1);
        repo.Add(entity2);

        foreach (var entity in repo.GetAll())
        {
            Console.WriteLine($"Entity Id: {entity.Id}");
        }

        var foundEntity = repo.GetById(1);
        Console.WriteLine($"Found entity with Id 1: {foundEntity.Id}");

        repo.Remove(entity1);
        Console.WriteLine($"Entities left after removal: {repo.GetAll().Count()}");
        repo.Save();
    }
}
