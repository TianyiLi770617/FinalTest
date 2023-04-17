namespace NetFinalTestCodes
{

    // Define a generic class that constrains the developer to only instantiate the class based on value types
    public class ValuesCollection<T> where T : struct, IComparable<T>
    {
        // Declare a private generic collection
        private List<T> _items;

        // Define a constructor that initializes the private collection
        public ValuesCollection()
        {
            _items = new List<T>();
        }

        // Define a method to add items to the private collection
        public void AddItem(T item)
        {
            _items.Add(item);
        }

        // Define a method that will return an item from the list
        public T GetItem(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                return _items[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
        }

        // Define a method that returns a sorted collection with the items in descending order
        public IEnumerable<T> GetSortedDescending()
        {
            return _items.OrderByDescending(x => x);
        }


    }
}