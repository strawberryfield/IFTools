using System.Text;

namespace Casasoft.IF.GBlorbLib;

public static class Helpers
{
    public static string ReadString(byte[] data, int offset, int length)
    {
        return Encoding.ASCII.GetString(data, offset, length);
    }
    public static Int32 ReadInt32(byte[] data, int offset)
    {
        if (BitConverter.IsLittleEndian)
        {
            byte[] temp = new byte[4];
            data.Skip(offset).Take(4).Reverse().ToArray().CopyTo(temp, 0);
            return BitConverter.ToInt32(temp, 0);
        }
        else
        {
            return BitConverter.ToInt32(data, offset);
        }

    }
    public static void WriteString(byte[] data, int offset, string value)
    {
        Encoding.ASCII.GetBytes(value).CopyTo(data, offset);
    }
    public static void WriteInt32(byte[] data, int offset, Int32 value)
    {
        if (BitConverter.IsLittleEndian)
        {
            BitConverter.GetBytes(value).Reverse().ToArray().CopyTo(data, offset);
        }
        else
        {
            BitConverter.GetBytes(value).CopyTo(data, offset);
        }
       
    }
}
