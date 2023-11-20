using System;

[Serializable]
struct DataBlock
{
    byte offset;
    byte length;
    char c;
}

public class LZ77 {
    private bool CheckIsMatch(byte[] buffer, int pl, int pr, int bl, int br)
    {
        while()
    }
    private static (int offset,int length) Match(byte[] buffer,int pl,int pr,int bl,int br)
    {
        for(int i = br; i > bl; i--)
        {
            

        }
    }
    public static void Compress(int windowLength, int bufferLength, string inPath, string outPath)
    {
        if(File.Exists(inPath))
        {
            using(FileStream fs = new FileStream(inPath, FileMode.Open, FileAccess.Read))
            {
                //缓冲区应该不大于窗口大小，大于也没意义
                if(bufferLength > windowLength)
                {
                    bufferLength = windowLength;
                }
                byte[] bufffer = new byte[fs.Length+windowLength];
                fs.Read(bufffer, windowLength, (int)fs.Length);
                //前向缓冲区指针
                int preBufferL = windowLength;
                int preBufferR = windowLength + bufferLength - 1;

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