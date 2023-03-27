namespace Vector 
{
    public class MergeSortBottomUp : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K> 
        {
            // Verify parsed values
            if (array == null) throw new ArgumentNullException("Array Cannot Be Null");
            if (index < 0 || num < 0) throw new ArgumentOutOfRangeException("index or num was out of range");
            if (index >= num) throw new ArgumentException("index is greater or equal to num"); //equal might not be necessary but probably useful
            
            //Bottom-Up Merge Sort
            
        }
    }
}