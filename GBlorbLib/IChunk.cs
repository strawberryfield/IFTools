namespace Casasoft.IF.GBlorbLib;

/// <summary>
/// Represents a chunk of data with a name, length, and address.
/// </summary>
public interface IChunk
{
    #region Properties
    /// <summary>
    /// Gets or sets the name of the chunk.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the length of the chunk.
    /// </summary>
    Int32 Length { get; set; }

    /// <summary>
    /// Gets or sets the address of the chunk.
    /// </summary>
    Int32 Address { get; set; }
    #endregion

    #region Methods
    /// <summary>
    /// Writes data to the chunk at the specified offset.
    /// </summary>
    /// <param name="data">The data to write.</param>
    /// <param name="offset">The offset at which to start writing.</param>
    void Write(byte[] data, int offset);

    /// <summary>
    /// Exports the chunk to a file.
    /// </summary>
    /// <param name="filename">The name of the file to export to.</param>
    void Export(string filename);

    /// <summary>
    /// Determines whether the chunk is a resource.
    /// </summary>
    /// <returns>True if the chunk is a resource; otherwise, false.</returns>
    bool IsResource();

    string FileExtension();
    #endregion
}
