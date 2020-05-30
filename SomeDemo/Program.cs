using System;

namespace SomeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new LinqDemo.LinqDemo2().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }
    }

    class A
    {
        public void test(int i)
        {
            Console.WriteLine(i);
            lock (this)
            {
                if (i > 10)
                {
                    i--;
                    test(i);
                }
            }
        }
        public string Val { get; set; }
        public override bool Equals(object obj)
        {
            Console.WriteLine("equ");
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            Console.WriteLine("hash");
            return base.GetHashCode();
        }
    }
}
