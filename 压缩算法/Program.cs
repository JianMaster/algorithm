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
        private static (int, int) Match(byte[] buffer, int pl, int windowLength, int pr, int bufferLength)
    {
        int start = pl, maxLength = 1, endIdx = pl + windowLength;
        for (int i = pl; i < endIdx; i++)
        {
            int length = 0;
            for (int j = 0; j < bufferLength; j++)
            {
                if (i + j == endIdx)
                {
                    break;
                }
                if (buffer[i + j] != buffer[pr + j])
                {
                    break;
                }
                length++;
            }
            if (length > maxLength)
            {
                maxLength = length;
                start = i;
            }

        }
        return (start, maxLength);
    }
        public static void Main(string[] args)
        {
            
            B b = new B();
            A ba = new B();
            A a = new A();
            Console.WriteLine(a.GetType());
            Console.WriteLine(nameof(ProgramName.A));

            Console.WriteLine(ba is A);

            byte[] buffer = new byte[12]{1,2,3,1,2,5,  1,2,5,3,4,5};
            (int start, int length) = LZ77.Match(buffer, 0, 6, 6, 3);
            Console.WriteLine(start);
            Console.WriteLine(length);

            LZ77.Compress(100, 100, "D:\\Users\\PC5080\\Desktop\\gitProject\\algorithm\\压缩算法\\aa.txt", "D:\\Users\\PC5080\\Desktop\\gitProject\\algorithm\\压缩算法\\aa.lz77");
        }
    }
    
}