namespace Vector
{
    public class InsertionSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K> 
        {
            // Verify parsed values
            if (array == null) throw new ArgumentNullException("Array Cannot Be Null");
            if (index < 0 || num < 0) throw new ArgumentOutOfRangeException("index or num was out of range");
            if (index >= num) throw new ArgumentException("index is greater or equal to num"); //equal might not be necessary but probably useful
            
            for (int i = index+1; i < num; i++)
            {
                // iterate until the next two values should not be swapped
                int j = i;
                while (j>index && comparer.Compare(array[j-1],array[j]) > 0)
                {
                    //Swap the values
                    K temp = array[j];
                    array[j] = array[j-1];
                    array[j-1] = temp;
                    j--;
                }
            }
        }
    }
}