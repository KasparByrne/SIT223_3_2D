namespace Vector 
{
    public class SelectionSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K> 
        {
            // Verify parsed values
            if (array == null) throw new ArgumentNullException("Array Cannot Be Null");
            if (index < 0 || num < 0) throw new ArgumentOutOfRangeException("index or num was out of range");
            if (index > array.Length || num + index > array.Length) throw new ArgumentException("One or more values is outside the array");
            
            for (int i = index; i < num-1; i++)
            {
                int min = i;
                for (int j = i+1; j < num; j++)
                {
                    if (comparer.Compare(array[j],array[min]) < 0) min = j; // if j is smaller than the current min, set min to j
                }
                if (min != i) // check that min is not the currently selected value
                {
                    // Swap min and i
                    K temp = array[i];
                    array[i] = array[min];
                    array[min] = temp;
                }
            }
        }
    }
}