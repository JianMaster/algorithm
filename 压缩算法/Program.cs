using System;
using System.Text;
namespace ProgramName
{
    class A
    {
        int a;
    }
    class B : A
    {

    }
    public class Program
    {
        public static void Main(string[] args)
        {
            
            B b = new B();
            A ba = new B();
            A a = new A();
            Console.WriteLine(a.GetType());
            Console.WriteLine(nameof(ProgramName.A));

            Console.WriteLine(ba is A);
        }
    }
}