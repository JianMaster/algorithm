using System;

[Serializable]
struct DataBlock
{
    byte offset;
    byte length;
    char c;
}

public class LZ77 {
    public static void Compress(int windowLength, int bufferLength, string inPath, string outPath)
    {
        if(File.Exists(inPath))
        {
            using(FileStream fs = new FileStream(inPath, FileMode.Open, FileAccess.Read))
            {
                byte[] bufffer = new byte[fs.Length+windowLength];
                fs.Read(bufffer, windowLength, (int)fs.Length);
                //前向缓冲区指针
                int preBufferL = windowLength;
                int preBufferR = windowLength + bufferLength;

                //滑动窗口指针
                int ptrL = 0;
                int prtR = windowLength - 1;

                List<DataBlock> list = new List<DataBlock>();


            }
        }
    }
    public static void Decompress()
    {

    }
}