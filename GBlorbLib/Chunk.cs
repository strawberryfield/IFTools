namespace Casasoft.IF.GBlorbLib;

/// <summary>
/// Represents a chunk of data with a name, length, and address.
/// </summary>
public class Chunk : IChunk
{
    #region Properties
    /// <summary>
    /// Gets or sets the name of the chunk.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the length of the chunk.
    /// </summary>
    public Int32 Length { get; set; }

    /// <summary>
    /// Gets or sets the address of the chunk.
    /// </summary>
    public Int32 Address { get; set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Chunk"/> class with a default name.
    /// </summary>
    public Chunk() : this(new string(' ', 4))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Chunk"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name of the chunk.</param>
    public Chunk(string name)
    {
        Name = name;
        Length = 0;
        Address = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Chunk"/> class with the specified data and offset.
    /// </summary>
    /// <param name="data">The byte array containing the chunk data.</param>
    /// <param name="offset">The offset within the byte array where the chunk starts.</param>
    public Chunk(byte[] data, int offset)
    {
        Name = Helpers.ReadString(data, offset, 4);
        Length = Helpers.ReadInt32(data, offset + 4);
        Address = IsResource() ? offset : 0;
    }
    #endregion

    #region Methods
    #region Public Methods
    /// <summary>
    /// Returns a string that represents the current chunk.
    /// </summary>
    /// <returns>A string that represents the current chunk.</returns>
    public override string ToString() { return $"{Name}\t{Length,7}"; }

    /// <summary>
    /// Writes the chunk data to the specified byte array at the given offset.
    /// </summary>
    /// <param name="data">The byte array to write the chunk data to.</param>
    /// <param name="offset">The offset within the byte array where the chunk data should be written.</param>
    public virtual void Write(byte[] data, int offset)
    {
        Helpers.WriteString(data, offset, Name);
        Helpers.WriteInt32(data, offset + 4, Length);
    }

    /// <summary>
    /// Exports the chunk data to the specified file.
    /// </summary>
    /// <param name="filename">The name of the file to export the chunk data to.</param>
    public virtual void Export(string filename)
    {
    }

    /// <summary>
    /// Determines whether the chunk is a resource.
    /// </summary>
    /// <returns><c>true</c> if the chunk is a resource; otherwise, <c>false</c>.</returns>
    public virtual bool IsResource() => false;

    public virtual string FileExtension() => ".dat";
    #endregion

    #region Protected Methods
    /// <summary>
    /// Skips zero bytes in the specified byte array starting from the given offset.
    /// </summary>
    /// <param name="data">The byte array to skip zero bytes in.</param>
    /// <param name="offset">The offset within the byte array to start skipping zero bytes from.</param>
    protected void SkipZeroBytes(byte[] data, int offset)
    {
        for (int i = offset; i < data.Length; i++)
        {
            if (data[i] != 0)
                break;
            Length++;
        }
    }
    #endregion
    #endregion
}
