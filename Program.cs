namespace SecondLargestSmallest
{
    internal class Program
    {

        //Problem Statement: Given an array, find the second smallest and second largest element in the array.
        //Print ‘-1’ in the event that either of them doesn’t exist.
        static void Main(string[] args)
        {
            int[] myarr = { 5, 9, 2, 2, 4, 2, 9, 6, 7, 3 };
            Print3(myarr);
        }

        //BruteFore Approach

        static void Print(int[] myarr)
        {
            Array.Sort(myarr);
            int n = myarr.Length;
            //This will work if no duplicates
            //Console.WriteLine("2nd Largest: " + myarr[myarr.Length - 2]);
            //Console.WriteLine("2nd Smallest: " + myarr[1]);

            for (int i = n - 2; i >= 0; i--)
            {
                if (myarr[i] < myarr[n-1])
                {
                    Console.WriteLine("2nd Largest: " + myarr[i]);
                    break;
                }
            }

            for(int i = 1; i <= n-1; i++)
            {
                if (myarr[i] > myarr[0])
                {
                    Console.WriteLine("2d Smallest: " + myarr[i]);
                    break;
                }
            }

        }

        //Better Apporach
        static void Print1(int[] a)
        {
            if (a.Length <= 1) Console.WriteLine(-1);
            
            int largest = a[0];
            int smallest = a[0];
            int secondLargest = -1;
            int secondSmallest = int.MaxValue;

            for(int i = 1; i < a.Length - 1; i++)
            {
                if (a[i] > largest)
                    largest = a[i];
                if (a[i] < smallest)
                    smallest = a[i];
            }
            
            for(int i = 0; i <= a.Length - 1;i++)
            {
                if (a[i] > secondLargest && a[i] != largest)
                    secondLargest = a[i];
                if (a[i] < secondSmallest && a[i] != smallest)
                    secondSmallest = a[i];
            }

            Console.WriteLine(secondLargest);
            Console.WriteLine(secondSmallest);
        }

        //Optimal Approach
        static void Print3(int[] a)
        {
            int largest = a[0];
            int secondLargest = int.MinValue;
            int smallest = a[0];
            int secondSmallest = int.MaxValue;

            for(int i = 1; i <= a.Length -1; i++)
            {
                if (a[i] > largest)
                {
                    secondLargest = largest;
                    largest = a[i];
                }
                else if (a[i] < largest && a[i] > secondLargest)
                {
                    secondLargest = a[i];
                }

                if (a[i] < smallest)
                {
                    secondSmallest = smallest;
                    smallest = a[i];
                }
                else if (a[i] != smallest && a[i] < secondSmallest)
                {
                    secondSmallest = a[i];
                }

            }

            Console.WriteLine(secondLargest);
            Console.WriteLine(secondSmallest);
        }
    }
}