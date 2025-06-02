// copyright (c) 2025 Roberto Ceccarelli - Casasoft
// http://strawberryfield.altervista.org
//
// This file is part of Casasoft IF Tools
// https://github.com/strawberryfield/IFTools
//
// Casasoft IF Tools is free software:
// you can redistribute it and/or modify it
// under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Casasoft IF Tools is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY

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
    /// Gets or sets the filler length of the chunk.
    /// </summary>
    public Int32 FillerLength { get; set; }

    /// <summary>
    /// Gets or sets the address of the chunk.
    /// </summary>
    public Int32 Address { get; set; }

    /// <summary>
    /// Gets or sets the resource ID of the chunk.
    /// </summary>
    public Int32 ResourceID { get; set; }
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
        FillerLength = 0;
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
    public override string ToString() => $"{Name}\t{Length,7}";

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
    /// Fills the specified byte array with zero at the given offset if the chunk length is odd.
    /// </summary>
    /// <param name="data">The byte array to fill with zero.</param>
    /// <param name="offset">The offset within the byte array where the zero should be written.</param>
    public virtual void FillZero(byte[] data, int offset)
    {
        if (Helpers.IsOdd(Length))
        {
            data[offset + 8 + Length] = 0;
        }
    }

    /// <summary>
    /// Gets the padded length of the chunk.
    /// </summary>
    /// <returns>The padded length, which is the chunk length plus one if the length is odd; otherwise, the chunk length.</returns>
    public Int32 PaddedLength() => Length + (Helpers.IsOdd(Length) ? 1 : 0);

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

    /// <summary>
    /// Gets the resource type of the chunk.
    /// </summary>
    /// <returns>The resource type as a string, or an empty string if the chunk is not a resource.</returns>
    public virtual string ResourceType() => string.Empty;

    /// <summary>
    /// Gets the file extension associated with the chunk.
    /// </summary>
    /// <returns>The file extension as a string.</returns>
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
            FillerLength++;
        }
    }
    #endregion
    #endregion
}
