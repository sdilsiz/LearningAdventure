using System;
using System.Collections.Generic;

namespace EqualityComparer
{
    class Program
    {


        static Dictionary<Box, String> boxes;

        static void Main()
        {
            BoxSameDimensions boxDim = new BoxSameDimensions();
            boxes = new Dictionary<Box, string>(boxDim);

            Console.WriteLine("Boxes equality by dimensions:");
            Box redBox = new Box(8, 4, 8);
            Box greenBox = new Box(8, 6, 8);
            Box blueBox = new Box(8, 4, 8);
            Box yellowBox = new Box(8, 8, 8);
            AddBox(redBox, "red");
            AddBox(greenBox, "green");
            AddBox(blueBox, "blue");
            AddBox(yellowBox, "yellow");

            Console.WriteLine();
            Console.WriteLine("Boxes equality by volume:");

            BoxSameVolume boxVolume = new BoxSameVolume();
            boxes = new Dictionary<Box, string>(boxVolume);
            Box pinkBox = new Box(8, 4, 8);
            Box orangeBox = new Box(8, 6, 8);
            Box purpleBox = new Box(4, 8, 8);
            Box brownBox = new Box(8, 8, 4);
            AddBox(pinkBox, "pink");
            AddBox(orangeBox, "orange");
            AddBox(purpleBox, "purple");
            AddBox(brownBox, "brown");
        }

        public static void AddBox(Box bx, string name)
        {
            try
            {
                boxes.Add(bx, name);
                Console.WriteLine("Added {0}, Count = {1}, HashCode = {2}",
                    name, boxes.Count.ToString(), bx.GetHashCode());
            }
            catch (ArgumentException)
            {
                Console.WriteLine("A box equal to {0} is already in the collection.", name);
            }
        }
    }

    public class Box
    {
        public Box(int h, int l, int w)
        {
            this.Height = h;
            this.Length = l;
            this.Width = w;
        }
        public int Height { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
    }

    class BoxSameDimensions : EqualityComparer<Box>
    {
        public override bool Equals(Box b1, Box b2)
        {
            if (b1 == null && b2 == null)
                return true;
            else if (b1 == null || b2 == null)
                return false;

            return (b1.Height == b2.Height &&
                    b1.Length == b2.Length &&
                    b1.Width == b2.Width);
        }

        public override int GetHashCode(Box bx)
        {
            int hCode = bx.Height ^ (bx.Length ^ bx.Width);
            return hCode.GetHashCode();
        }
    }

    class PencilSameDimensions : EqualityComparer<Pencil>
    {

        public override bool Equals(Pencil h1, Pencil h2)
        {
            if (h1 == null && h2 == null)
                return true;
            else if (h1 == null || h2 == null)
                return false;

            return (h1.Color * h1.Length * h1.Type ==
                    h2.Color * h2.Length * h2.Type);
        }
        public override int GetHashCode(Pencil pencil)
        {
            int hCode = pencil.Color * pencil.Length * pencil.Type;
            return hCode.GetHashCode();
        }

    }
    class BoxSameVolume : EqualityComparer<Box>
    {
        public override bool Equals(Box b1, Box b2)
        {
            if (b1 == null && b2 == null)
                return true;
            else if (b1 == null || b2 == null)
                return false;

            return (b1.Height * b1.Width * b1.Length ==
                    b2.Height * b2.Width * b2.Length);
        }

        public override int GetHashCode(Box bx)
        {
            int hCode = bx.Height * bx.Length * bx.Width;
            return hCode.GetHashCode();
        }
    }

    class Pencil
    {
        public Pencil(int h, int l, int w)
        {
            this.Color = h;
            this.Length = l;
            this.Type = w;
        }
        public int Color { get; set; }
        public int Length { get; set; }
        public int Type { get; set; }
    }


}
