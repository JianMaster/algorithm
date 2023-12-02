using System;

[Serializable]
struct DataBlock
{
    public DataBlock(byte offset, byte length, byte b)
    {
        this.offset = offset;
        this.length = length;
        this.b = b;
    }
    public byte offset;
    public byte length;
    public byte b;
}

public class LZ77
{
    public static (int, int) Match(byte[] buffer, int pl, int windowLength, int pr, int bufferLength)
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
    public static void Compress(byte windowLength, byte bufferLength, string inPath, string outPath)
    {
        if (File.Exists(inPath))
        {
            byte[] newBuffer;
            using (FileStream fs = new FileStream(inPath, FileMode.Open, FileAccess.Read))
            {
                if (bufferLength > windowLength)
                {
                    bufferLength = windowLength;
                }
                byte[] buffer = new byte[fs.Length + windowLength];
                //缓冲区应该不大于窗口大小，大于也没意义
                fs.Read(buffer, windowLength, (int)fs.Length);
                //前向缓冲区指针
                int preBufferL = windowLength;
                int preBufferR = windowLength + bufferLength - 1;

                //滑动窗口指针
                int ptrL = 0;
                int prtR = windowLength - 1;

                List<DataBlock> list = new List<DataBlock>();
                while (preBufferR < buffer.Length)
                {
                    (int start, int length) = Match(buffer, ptrL, windowLength, preBufferL, bufferLength);
                    if (length != 1)
                    {
                        list.Add(new DataBlock((byte)(start - ptrL), (byte)length, buffer[preBufferL + length]));
                        length += 1;
                    }
                    else
                    {
                        list.Add(new DataBlock(0, 0, buffer[preBufferL]));
                    }
                    ptrL += length;
                    prtR += length;
                    preBufferL += length;
                    preBufferR += length;

                }

                newBuffer = new byte[list.Count * 3];
                for (int i = 0; i < list.Count; i++)
                {
                    newBuffer[i * 3] = list[i].offset;
                    newBuffer[i * 3 + 1] = list[i].length;
                    newBuffer[i * 3 + 2] = list[i].b;
                }
            }

            using (FileStream fs = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.Write)){
                fs.Write(newBuffer, 0, newBuffer.Length);
            }
        }
    }
    public static void Decompress()
    {

    }
}