﻿using System;
using System.Collections.Generic;

namespace Vector
{

    public class AscendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A - B;
        }
    }

    public class DescendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return B - A;
        }
    }

    public class EvenNumberFirstComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A % 2 - B % 2;
        }
    }

    // -------------------- CUSTOM COMPARERS ----------------------
    // Sort string by their length in ascending order
    public class AscendingStrLenComparer : IComparer<string>
    {
        public int Compare(string A, string B)
        {
            return A.Length - B.Length;
        }
    }

    class Tester
    {
        private static bool CheckAscending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] > vector[i + 1]) return false;
            return true;
        }

        private static bool CheckDescending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] < vector[i + 1]) return false;
            return true;
        }

        private static bool CheckEvenNumberFirst(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] % 2 > vector[i + 1] % 2) return false;
            return true;
        }
        
        // ----------------------- CUSTOM CHECKS ------------------------
        private static bool CheckAscendingStrLen(string[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].Length > array[i+1].Length) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            string result = "";
            int problem_size = 20;
            int[] data = new int[problem_size]; data[0] = 333;
            Random k = new Random(1000);
            for (int i = 1; i < problem_size; i++) data[i] = 100 + k.Next(900);

            Vector<int> vector = null;

            // ------------------ RandomizedQuickSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest A: Sort integer numbers applying RandomizedQuickSort with the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new RandomizedQuickSort(),new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "A";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest B: Sort integer numbers applying RandomizedQuickSort with the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new RandomizedQuickSort(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "B";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest C: Sort integer numbers applying RandomizedQuickSort with the EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new RandomizedQuickSort(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "C";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }



            // ------------------ MergeSortTopDown ----------------------------------

            try
            {
                Console.WriteLine("\nTest D: Sort integer numbers applying MergeSortTopDown with the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new MergeSortTopDown(), new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "D";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest E: Sort integer numbers applying MergeSortTopDown with the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new MergeSortTopDown(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "E";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest F: Sort integer numbers applying MergeSortTopDown with the EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new MergeSortTopDown(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "F";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }



            // ------------------ MergeSortBottomUp ----------------------------------

            try
            {
                Console.WriteLine("\nTest G: Sort integer numbers applying MergeSortBottomUp with the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new MergeSortBottomUp(), new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "G";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest H: Sort integer numbers applying MergeSortBottomUp with the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new MergeSortBottomUp(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "H";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest I: Sort integer numbers applying MergeSortBottomUp with the EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new MergeSortBottomUp(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "I";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }
            //------------------------------- CUSTOM TESTS - RAND QUICK SORT -----------------------------
            // Test that sort can handle type other than int
            try
            {
                Console.WriteLine("\nTest 1: Sort strings applying BubbleSort with the AscendingStrLenComparer: ");
                string[] array = {"Bob", "ABC", "A", "ABCDEFGHI", "Michael", "Ti", "santa", "mcnDt13", "moon", "because", "wikipedia", "happiness"}; // array of hard coded random words
                RandomizedQuickSort testSort = new RandomizedQuickSort();
                Console.Write("Initial data: ");
                foreach (string i in array) Console.Write(i + " ");
                Console.Write("\n");
                testSort.Sort(array, 0, array.Length, new AscendingStrLenComparer());
                Console.Write("Resulting order: ");
                foreach (string i in array) Console.Write(i + " ");
                Console.Write("\n");
                if (!CheckAscendingStrLen(array))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "1";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }
            //------------------------------- CUSTOM TESTS - MERGE SORT TOP DOWN -----------------------------
            // Test that sort can handle type other than int
            try
            {
                Console.WriteLine("\nTest 1: Sort strings applying BubbleSort with the AscendingStrLenComparer: ");
                string[] array = {"Bob", "ABC", "A", "ABCDEFGHI", "Michael", "Ti", "santa", "mcnDt13", "moon", "because", "wikipedia", "happiness"}; // array of hard coded random words
                MergeSortTopDown testSort = new MergeSortTopDown();
                Console.Write("Initial data: ");
                foreach (string i in array) Console.Write(i + " ");
                Console.Write("\n");
                testSort.Sort(array, 0, array.Length, new AscendingStrLenComparer());
                Console.Write("Resulting order: ");
                foreach (string i in array) Console.Write(i + " ");
                Console.Write("\n");
                if (!CheckAscendingStrLen(array))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "2";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }
            //------------------------------- CUSTOM TESTS - MERGE SORT BOTTOM UP -----------------------------
            // Test that sort can handle type other than int
            try
            {
                Console.WriteLine("\nTest 1: Sort strings applying BubbleSort with the AscendingStrLenComparer: ");
                string[] array = {"Bob", "ABC", "A", "ABCDEFGHI", "Michael", "Ti", "santa", "mcnDt13", "moon", "because", "wikipedia", "happiness"}; // array of hard coded random words
                MergeSortBottomUp testSort = new MergeSortBottomUp();
                Console.Write("Initial data: ");
                foreach (string i in array) Console.Write(i + " ");
                Console.Write("\n");
                testSort.Sort(array, 0, array.Length, new AscendingStrLenComparer());
                Console.Write("Resulting order: ");
                foreach (string i in array) Console.Write(i + " ");
                Console.Write("\n");
                if (!CheckAscendingStrLen(array))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "3";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();
        }

    }
}
