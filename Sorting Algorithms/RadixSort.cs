using System;
namespace _433_PA1
{
    public class RadixSort
    {
        private readonly int[] array;
        private readonly int n;

        public RadixSort(int[] array, int length)
        {
            this.array = array;
            this.n = length;
        }

        private static void countSortOnDigits(int[] A, int n, int[] digits)
        { // complete this function
            int[] C = new int[10];
            int[] T = new int[n];
            for (int i = 0; i <= n-1; i++)
                C[digits[i]]++;
            for (int i = 1; i < 10; i++)
                C[i] = C[i - 1] + C[i];
            for(int i=n-1; i >= 0; i--)
            {
                C[digits[i]]--;
                T[C[digits[i]]] = A[i];
            }
            for (int i = 0; i < T.Length; i++)
                A[i] = T[i];
        }

        private static void radixSortNonNeg(int[] A, int n)
        { // complete this function
            int m = A[0];
            for (int i = 0; i < A.Length; i++)
                if (m < A[i])
                    m = A[i];
            int[] digits = new int[n];
            int e = 1;
            while(m/e > 0)
            {
                for (int i = 0; i <= n-1; i++)
                    digits[i] = (A[i] / e) % 10;
                countSortOnDigits(A, n, digits);
                e = e * 10;
            }
        }

        public void radixSort()
        { // complete this function
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
                if (min > array[i])
                    min = array[i];
            if (min > 0)
            {
                radixSortNonNeg(array, n);
                return;
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] -= min;
            }
            
            radixSortNonNeg(array, n);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] += min;
            }
        }
    }
}
