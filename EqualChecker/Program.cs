using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace EqualChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");


            var d1 = DateTime.Now.Date;
            var d2 = DateTime.Now.Date;

            Console.WriteLine(d1 == d2); // Writes True

            var sb1 = new StringBuilder("Blue");
            var sb2 = new StringBuilder("Blue");

            Console.WriteLine(sb1 == sb2);


            // Strings are highly optimized to share storage space. Using a StringBuilder is
            // a way to get two different string instances with the same value.
            var s1 = "Blue";
            var sb = new StringBuilder("Bl");
            sb.Append("ue");
            var s2 = sb.ToString();

            Console.WriteLine(s1 == s2); // True
            Console.WriteLine(object.ReferenceEquals(s1, s2)); // False

            var u1 = new Uri("http://localhost");
            var u2 = new Uri("http://localhost");
            Console.WriteLine(u1 == u2);  // True
            Console.WriteLine(object.ReferenceEquals(u1, u2)); // False

            var v1 = new Version(1, 2, 3);
            var v2 = new Version(1, 2, 3);
            Console.WriteLine(v1 == v2); // True
            Console.WriteLine(object.ReferenceEquals(v1, v2)); // False


            object o1 = s1;
            Console.WriteLine(o1 == s2); // False
            Console.WriteLine(s2 == o1); // False

            Console.WriteLine(s2.Equals(o1)); // True
            Console.WriteLine(o1.Equals(s2)); // True



            var favColours = new Dictionary<Person, string>();


            var p = new Person() {
                Age = 1,
                Name = "Alice"
            };

            favColours[p] = "Blue";

            // Happy birthday Alice!
            p.Age = 2;
            favColours[p] = "Green";

            Console.WriteLine(favColours.Count); // 2

            var keys = favColours.Keys.ToArray();
            Console.WriteLine(object.ReferenceEquals(keys[0], keys[1])); // True
        }


        public interface IEquatable<T>
        {
            bool Equals(T other);
        }

        struct Person
        {
            public int Age { get; set; }
            public string Name { get; set; }

            // A person is uniquely identified by name, so let's use it for equality.
            public override bool Equals(Object obj)
            {
                return (obj is Person) && ((Person)obj).Name == Name;
            }

            // For lazyness reasons we (incorrectly) use the age as the hash code.
            public override int GetHashCode()
            {
                return Age;
            }
        }
    }
}
