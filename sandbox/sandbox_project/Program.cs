using System;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        Console.WriteLine("Hello Sandbox World!");
        var result = Sets.IntersectionSet();
        var union = Sets.UnionSet();
        // foreach (var i in result)
        // {
        //     Console.WriteLine(i);
        // }
        foreach (var i in union)
        {
            Console.WriteLine(i);
        }
    }

    public class Sets
    {

        public static int[] IntersectionSet()
        {
            HashSet<int> set1 = new HashSet<int>() { 1, 2, 3, 4, 5 };
            HashSet<int> set2 = new HashSet<int>() { 2, 3, 4, 5, 6 };
            HashSet<int> result = new HashSet<int>();

            foreach (int i in set1)
            {
                if (set2.Contains(i))
                {
                    result.Add(i);
                }
            }
            return result.ToArray();
        }

        public static int[] UnionSet()
        {
            HashSet<int> set1 = new HashSet<int>() { 1, 2, 3, 4, 5 };
            HashSet<int> set2 = new HashSet<int>() { 2, 3, 4, 5, 6 };
            HashSet<int> result = new HashSet<int>();

            foreach (int i in set1)
            {
                result.Add(i);
            }
            foreach (int i in set2)
            {
                result.Add(i);
            }
            return result.ToArray();
        }
    }
}