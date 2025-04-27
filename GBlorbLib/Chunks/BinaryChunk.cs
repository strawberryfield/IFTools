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
/// Represents a binary chunk of data.
/// </summary>
public class BinaryChunk : Chunk
{
    #region Properties
    /// <summary>
    /// Gets or sets the content of the binary chunk.
    /// </summary>
    public byte[] Content { get; set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryChunk"/> class with a default name.
    /// </summary>
    public BinaryChunk() : this(new string(' ', 4))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryChunk"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name of the binary chunk.</param>
    public BinaryChunk(string name) : base(name)
    {
        Content = Array.Empty<byte>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryChunk"/> class with the specified data and offset.
    /// </summary>
    /// <param name="data">The byte array containing the chunk data.</param>
    /// <param name="offset">The offset within the byte array where the chunk starts.</param>
    public BinaryChunk(byte[] data, int offset) : base(data, offset)
    {
        Content = new byte[Length];
        Array.Copy(data, offset + 8, Content, 0, Length);
        SkipZeroBytes(data, offset + 8 + Length);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Exports the binary chunk to the specified file.
    /// </summary>
    /// <param name="filename">The name of the file to export to.</param>
    public override void Export(string filename) => File.WriteAllBytes(filename, Content);

    /// <summary>
    /// Writes the binary chunk data to the specified byte array at the given offset.
    /// </summary>
    /// <param name="data">The byte array to write the chunk data to.</param>
    /// <param name="offset">The offset within the byte array where the chunk data should be written.</param>
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

    /// <summary>
    /// Gets the file extension for the binary chunk based on its name.
    /// </summary>
    /// <returns>The file extension for the binary chunk.</returns>
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

    /// <summary>
    /// Gets the resource type of the chunk based on its name.
    /// </summary>
    /// <returns>Resource type or empty string if unknown</returns>
    public override string ResourceType()
    {
        switch (Name)
        {
            case "BINA":
                return "Data";
            case "JPEG":
            case "PNG ":
                return "Pict";
            case "OGGV":
            case "AIFF":
            case "MIDI":
            case "MOD ":
                return "Snd ";
            case "ZCOD":
            case "GLUL":
                return "Exec";
            default:
                return base.ResourceType();
        }
    }
    #endregion
}

