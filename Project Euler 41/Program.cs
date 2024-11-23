using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Project_Euler_41
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger maxNum = 0;
            Console.Write("What number is it up to: ");
            maxNum = Convert.ToInt32(Console.ReadLine());
            List<BigInteger> primes = PrimeList(maxNum); // create a list of prime numbers under the number entered
            //a list is a dynamic data structure
            //it works in a similar way to an array
            //Count is the list version of Length for an array
            //indexing starts at 0 as with an array
            for (BigInteger i = 0; i < primes.Count; i++) //iterate through the list
            {
                //Console.Write(primes[i] + " ");//output the prime number
            }
            //Console.WriteLine();
            List<BigInteger> Numbers = new List<BigInteger>();
            for (int i = 0; i < primes.Count; i++)
            {
                int counter = 0;
                for (int j = 1; j <= primes[i].ToString().Length; j++)
                {
                    if (primes[i].ToString().Contains(j.ToString()))
                    {
                        counter++;
                    }
                }
                if (counter == primes[i].ToString().Length)
                {
                    Console.WriteLine(primes[i]);
                    Numbers.Add(primes[i]);
                }
            }

        }

        static List<BigInteger> PrimeList(BigInteger n)
        {
            // a list has a data type in the same way an array does
            List<BigInteger> primes = new List<BigInteger>();
            bool[] nums = new bool[1000000000];
            for (int i = 2; i < nums.Length; i++)
            {
                nums[i] = true;
            }
            // for i = 2, 3, 4, ..., not exceeding √n do
            for (int i = 2; i <  Sqrt(n); i++)
            {
                //if A[i] is true
                if (nums[i])
                {
                    //for j = i2, i2 + i, i2 + 2i, i2 + 3i, ..., not exceeding n do
                    for (int j = i * i; j < n; j += i)
                    {
                        nums[j] = false; //set A[j] := false
                    }
                }

            }
            // This goes through the boolean array and if the number is prime
            // it adds it to a list 
            // this results in a list only containing prime numbers
            for (int i = 2; i < n; i++)
            {
                if (nums[i])
                {
                    primes.Add(i); //adding an item to a list adds it at the end
                }
            }
            return primes;
        }

        static BigInteger Sqrt(BigInteger n)
        {
            if (n == 0) return 0;
            if (n < 0) throw new ArgumentException("Cannot compute square root of a negative number");

            BigInteger left = 1;
            BigInteger right = n;
            BigInteger mid;

            while (left <= right)
            {
                mid = (left + right) / 2;
                BigInteger midSquared = mid * mid;

                if (midSquared == n)
                    return mid;
                else if (midSquared < n)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return right;
        }
    }
}
