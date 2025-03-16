namespace Casasoft.IF.GBlorbLib;

class TextChunk : Chunk
{
    #region Properties
    public string Content { get; set; }
    #endregion

    #region Constructors
    public TextChunk() : base()
    {
        Content = string.Empty;
    }

    public TextChunk(string name) : base(name)
    {
        Content = string.Empty;
    }

    public TextChunk(byte[] data, int offset) : base(data, offset)
    {
        Content = Helpers.ReadString(data, offset + 8, Length);
        SkipZeroBytes(data, offset + 8 + Length);
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        string ret = base.ToString();
        if (Name == "AUTH" || Name == "ANNO" || Name == "(c) ")
        {
            ret += $"\t{Content}";
        }
        return ret;
    }
    public override void Export(string filename) => File.WriteAllText(filename, Content);

    public override void Write(byte[] data, int offset)
    {
        base.Write(data, offset);
        Helpers.WriteString(data, offset + 8, Content);
    }

    /// <summary>
    /// Determines whether the chunk is a resource.
    /// </summary>
    /// <returns><c>true</c> if the chunk is a resource; otherwise, <c>false</c>.</returns>
    public override bool IsResource()
    {
        switch (Name)
        {
            case "IFmd":
            case "TEXT":
                return true;
            default:
                return false;
        }
    }

    public override string FileExtension()
    {
        switch (Name)
        {
            case "IFmd":
                return ".xml";
            case "TEXT":
                return ".txt";
            default:
                return base.FileExtension();
        }
    }
    #endregion
}
