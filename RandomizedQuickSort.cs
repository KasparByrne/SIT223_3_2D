namespace Vector 
{
    public class RandomizedQuickSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K> 
        {
            // Verify parsed values
            if (array == null) throw new ArgumentNullException("Array Cannot Be Null");
            if (index < 0 || num < 0) throw new ArgumentOutOfRangeException("index or num was out of range");
            if (index >= num) throw new ArgumentException("index is greater or equal to num"); //equal might not be necessary but probably useful
            
            //Randomized Quick Sort
            QuickSort(array, index, num, comparer);
        }

        private void QuickSort<K>(K[] array, int lo, int hi, IComparer<K> comparer) where K : IComparable<K>
        {
            //terminate sort branch once complete
            if (lo >= hi || lo < 0) return;

            // Compare & Sort
            for (int i = lo; i < hi-1; i++)
            {
                // Swap elements
                if (comparer.Compare(array[i],array[i+1]) > 0) 
                {
                    K temp = array[i];
                    array[i] = array[i+1];
                    array[i+1] = temp;
                }
            }

            // Select pivot
            var random = new Random();
            int p = random.Next(lo,hi);

            // Sort partion and sort
            QuickSort(array, lo, p-1, comparer);
            QuickSort(array, p+1, hi, comparer);
        }
    }
}