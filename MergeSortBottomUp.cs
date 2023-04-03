namespace Vector 
{
    public class MergeSortBottomUp : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K> 
        {
            // Verify parsed values
            if (array == null) throw new ArgumentNullException("Array Cannot Be Null");
            if (index < 0 || num < 0) throw new ArgumentOutOfRangeException("index or num was out of range");
            if (index > array.Length || num + index > array.Length) throw new ArgumentException("One or more values is outside the array");

            K[] array_copy = new K[num];
            Array.Copy(array, array_copy, num); // copy array to array_copy
            
            //Bottom-Up Merge Sort
            // start with small partitions and go up to bigger and bigger partitions
            for (int width = 1; width < num; width = 2 * width)
            {
                // iterate through current partition
                for (int i = index; i < num; i = i + 2 * width)
                {
                    BottomUpMerge(array, i, Math.Min(i+width, num), Math.Min(i+2*width, num), array_copy, comparer); // min chooses the smallest value of the parsed values
                }
                Array.Copy(array_copy, array, num); // copy array to array_copy
            }
        }

        private void BottomUpMerge<K>(K[] array, int left, int right, int end, K[] array_copy, IComparer<K> comparer) where K : IComparable<K>
        {
            int i = left, j = right;
            // compare left and right values and merge
            for (int n = left; n < end; n++)
            {
                if (i < right && (j >= end || comparer.Compare(array[i], array[j]) <= 0))
                {
                    array_copy[n] = array[i];
                    i++;
                } else {
                    array_copy[n] = array[j];
                    j++;
                }
            }
        }
    }
}