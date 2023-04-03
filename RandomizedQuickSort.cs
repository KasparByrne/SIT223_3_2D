namespace Vector 
{
    public class RandomizedQuickSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K> 
        {
            // Verify parsed values
            if (array == null) throw new ArgumentNullException("Array Cannot Be Null");
            if (index < 0 || num < 0) throw new ArgumentOutOfRangeException("index or num was out of range");
            if (index > array.Length || num + index > array.Length) throw new ArgumentException("One or more values is outside the array");

            // Randomized Quick Sort
            QuickSort(array, index, num - 1, comparer);
        }

        private void QuickSort<K>(K[] array, int lo, int hi, IComparer<K> comparer) where K : IComparable<K>
        {
            // Terminate sort branch once complete
            if (lo >= hi || lo < 0) return;

            // create a new partition with a random pivot
            int p = rand_partition(array, lo, hi, comparer);

            // Sort partion and sort
            QuickSort(array, lo, p-1, comparer);
            QuickSort(array, p+1, hi, comparer);
        }

        private int rand_partition<K>(K[] array, int lo, int hi, IComparer<K> comparer) where K : IComparable<K>
        {
            // Select a random pivot
            var random = new Random();
            int p = random.Next(lo, hi);

            // swap p and hi
            K temp = array[p];
            array[p] = array[hi];
            array[hi] = temp;

            return partition(array, lo, hi, comparer);
        }
        
        private int partition<K>(K[] array, int lo, int hi, IComparer<K> comparer) where K : IComparable<K>
        {
            K temp; // variable for swaps
            K pivot = array[hi];
            int i = lo;
            for (int j = lo; j < hi; j++)
            {
                if (comparer.Compare(array[j],pivot) <= 0)
                {
                    // Shift i up if j is less than or equal to pivot
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                }
            }

            // Swap i with hi
            temp = array[i];
            array[i] = array[hi];
            array[hi] = temp;

            // return new pivot
            return i;
        }
    }
}