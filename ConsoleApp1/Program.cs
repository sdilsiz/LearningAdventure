using System;
using System.Linq;

namespace ConsoleApp1 {
    class Program {
        public static Func<int, string, string> UppercaseString = (str, index) => str + " " + index;

        static void Main(string[] args) {


            int[] numbers = { 1, 2, 3, 4 };
            string[] words = { "one", "two", "three" };
            //Func<string, string> selector = (first,  second) => first + " " + second;
            //Func<string, string, string> convertMethod = UppercaseString;
            
             
            // Use delegate instance to call UppercaseString method
            

            var numbersAndWords = words.Zip(numbers, (first, second) => first + " " + second);

            foreach (var item in numbersAndWords)
                Console.WriteLine(item);

            Console.ReadKey();
        }


         
    }
}
