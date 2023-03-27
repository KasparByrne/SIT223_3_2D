namespace Vector 
{
    public class BubbleSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K> 
        {
            // Verify parsed values
            if (array == null) throw new ArgumentNullException("Array Cannot Be Null");
            if (index < 0 || num < 0) throw new ArgumentOutOfRangeException("index or num was out of range");
            if (index >= num) throw new ArgumentException("index is greater or equal to num"); //equal might not be necessary but probably useful
            
            //Bubble Sort
            for (int i = index+1; i < num; i++)
            {
                int swaps = 0;
                for (int j = index; j < num-i; j++)
                {
                    if (comparer.Compare(array[j],array[j+1]) > 0) //check if the preceeding element should proceed the proceeding element !!!Real chance I messed this up!!!
                    {
                        // switch the elements
                        K temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                        swaps++; // note that a swap was made
                    }
                }
                if (swaps == 0) break; // terminate the sort
            }
        }
    }
}