namespace Vector 
{
    public class MergeSortTopDown : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K> 
        {
            // Verify parsed values
            if (array == null) throw new ArgumentNullException("Array Cannot Be Null");
            if (index < 0 || num < 0) throw new ArgumentOutOfRangeException("index or num was out of range");
            if (index > array.Length || num + index > array.Length) throw new ArgumentException("One or more values is outside the array");
            
            //Top-Down Merge Sort
            K[] array_copy = new K[num];
            Array.Copy(array, array_copy, num); // copy array to array_copy

            TopDownSplitMerge(array, index, num, array_copy, comparer);
        }

        private void TopDownSplitMerge<K>(K[] B, int start, int end, K[] A, IComparer<K> comparer) where K : IComparable<K>
        {
            if (end - start == 1) return; // if there is only 1 element to be sorted in the partition then it is sorted

            int mid = (end + start)/2;

            TopDownSplitMerge(A, start, mid, B, comparer);
            TopDownSplitMerge(A, mid, end, B, comparer);

            TopDownMerge(B, start, mid, end, A, comparer);
        }

        private void TopDownMerge<K>(K[] B, int start, int mid, int end, K[] A, IComparer<K> comparer) where K : IComparable<K>
        {
            int i = start, j = mid; // current index of both halves
            for (int n = start; n < end; n++)
            {
                // if the selected left value is less than the selected right value then insert it else insert the right value
                // if there are no values remaining on one side, insert all remaining values
                if (i < mid && (j >= end || comparer.Compare(A[i], A[j]) <= 0))
                {
                    B[n] = A[i];
                    i++;
                }
                else
                {
                    B[n] = A[j];
                    j++;
                }
            }
        }
    }
}