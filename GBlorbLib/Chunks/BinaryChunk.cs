namespace Casasoft.IF.GBlorbLib;

public class BinaryChunk : Chunk
{
    #region Properties
    public byte[] Content { get; set; }
    #endregion

    #region Constructors
    public BinaryChunk() : this(new string(' ', 4))
    {
    }

    public BinaryChunk(string name) : base(name)
    {
        Content = Array.Empty<byte>();
    }

    public BinaryChunk(byte[] data, int offset) : base(data, offset)
    {
        Content = new byte[Length];
        Array.Copy(data, offset + 8, Content, 0, Length);
        SkipZeroBytes(data, offset + 8 + Length);
    }
    #endregion

    #region Methods
    public override void Export(string filename) => File.WriteAllBytes(filename, Content);

    public override void Write(byte[] data, int offset)
    {
        base.Write(data, offset);
        Array.Copy(Content, 0, data, offset + 8, data.Length);
    }

    /// <summary>
    /// Determines whether the chunk is a resource.
    /// </summary>
    /// <returns><c>true</c> if the chunk is a resource; otherwise, <c>false</c>.</returns>
    public override bool IsResource()
    {
        switch (Name)
        {
            case "BINA":
            case "JPEG":
            case "PNG ":
            case "OGGV":
            case "AIFF":
            case "MIDI":
            case "MOD ":
            case "ZCOD":
            case "GLUL":
                return true;
            default:
                return false;
        }
    }

    public override string FileExtension()
    {
        switch (Name)
        {
            case "BINA":
                return ".bin";
            case "JPEG":
                return ".jpg";
            case "PNG ":
                return ".png";
            case "OGGV":
                return ".ogg";
            case "AIFF":
                return ".aiff";
            case "MIDI":
                return ".mid";
            case "MOD ":
                return ".mod";
            case "ZCOD":
                return ".z3";
            case "GLUL":
                return ".ulx";
            default:
                return base.FileExtension();
        }
    }
    #endregion
}

