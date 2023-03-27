using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector<T> where T : IComparable<T>
    {
        // This constant determines the default number of elements in a newly created vector.
        // It is also used to extended the capacity of the existing vector
        private const int DEFAULT_CAPACITY = 10;

        // This array represents the internal data structure wrapped by the vector class.
        // In fact, all the elements are to be stored in this private  array. 
        // You will just write extra functionality (methods) to make the work with the array more convenient for the user.
        private T[] data;

        // This property represents the number of elements in the vector
        public int Count { get; private set; } = 0;

        // This property represents the maximum number of elements (capacity) in the vector
        public int Capacity
        {
            get { return data.Length; }
        }

        // This is an overloaded constructor
        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        // This is the implementation of the default constructor
        public Vector() : this(DEFAULT_CAPACITY) { }

        // An Indexer is a special type of property that allows a class or structure to be accessed the same way as array for its internal collection. 
        // For example, introducing the following indexer you may address an element of the vector as vector[i] or vector[0] or ...
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        // This private method allows extension of the existing capacity of the vector by another 'extraCapacity' elements.
        // The new capacity is equal to the existing one plus 'extraCapacity'.
        // It copies the elements of 'data' (the existing array) to 'newData' (the new array), and then makes data pointing to 'newData'.
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[Capacity + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }

        // This method adds a new element to the existing array.
        // If the internal array is out of capacity, its capacity is first extended to fit the new element.
        public void Add(T element)
        {
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY);
            data[Count] = element;
            Count++;
        }

        // This method searches for the specified object and returns the zero‐based index of the first occurrence within the entire data structure.
        // This method performs a linear search; therefore, this method is an O(n) runtime complexity operation.
        // If occurrence is not found, then the method returns –1.
        // Note that Equals is the proper method to compare two objects for equality, you must not use operator '=' for this purpose.
        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1;
        }

        // TODO: Your task is to implement all the remaining methods.
        // Read the instruction carefully, study the code examples from above as they should help you to write the rest of the code.

        // Insert a value at the parsed index
        public void Insert(int index, T element)
        {
            //Raise exception if trying to insert element out of range
            if (index > Count || index < 0) throw new IndexOutOfRangeException();

            if (index == Count) Add(element); //just add if last element
            else {
                Count++; // increase count for insert
                if (Count == Capacity) ExtendData(1); //extend capcity if needed
                
                // Shift current elements to make room for insert
                for (int i = Count ; i > index ; i--) {
                    data[i] = data[i-1]; //set current element as previous element
                }
                // Insert new element
                data[index] = element;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Count ; i++) data[i] = default(T);
            Count = 0;
        }

        // Alternatively : return !(indexOf(element) == -1)
        public bool Contains(T element)
        {
            foreach(T value in data) {
                if (value.Equals(element)) return true; //return true if the element is found
            }
            return false;
        }

        // This method removes the first element that matches the parsed element
        public bool Remove(T element)
        {
            bool result = false; //if the method does not remove any elements then return false
            // loop through the elements of the array
            int newCount = 0;
            for(int i = 0; i < Count; i++) {
                //Skip the first element that equal the parsed element
                if(data[i].Equals(element) && !result) {
                    result = true;
                }
                //shift all elements past the removed element down
                else if (result) {
                    data[newCount] = data[i];
                    newCount++; //Increase new count
                }
            }
            // Update properties
            Count = newCount;
            return result;
        }

        public void RemoveAt(int index)
        {
            //Throw exception if trying to remove element out of range
            if (index >= Count || index < 0) throw new IndexOutOfRangeException();

            int newCount = 0;
            for (int i = 0; i < Count; i++) {
                if (i != index) {data[newCount] = data[i]; newCount++;} //Skip element index to remove, add all other elements
            }
            //Update properties
            Count--;
        }

        public override string ToString()
        {
            string asString = ""; //create an empty string

            for (int i = 0; i < Count; i++) {
                asString += ((object)data[i]).ToString() + " "; //Casting to an object first lets ToString handle the convertion
            }

            return asString; 
        }
        
        //Sort data using the default method
        public void Sort() {
            Array.Sort(data,0,Count);
        }

        //Sort data using a parsed comparer
        public void Sort(IComparer<T> comparer) {
            if (comparer != null) Array.Sort(data,0,Count,comparer);
            else Array.Sort(data,0,Count);
        }

        public void Sort(ISorter algorithm, IComparer<T> comparer) {
            if (algorithm == null && comparer == null ) Array.Sort(data); //use default sort and comparer
            else if (algorithm == null) Array.Sort(data,comparer); //use default sort and parsed comparer
            else if (comparer == null) algorithm.Sort(data,0,Count,Comparer<T>.Default); //use parsed algorithm but default comparer
            else algorithm.Sort(data,0,Count,comparer); //use parsed algorithm and comparer
            
        }

    }
}
