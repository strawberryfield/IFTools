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
/// Represents a text chunk in a Blorb file.
/// </summary>
class TextChunk : Chunk
{
    #region Properties
    /// <summary>
    /// Gets or sets the content of the text chunk.
    /// </summary>
    public string Content { get; set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="TextChunk"/> class.
    /// </summary>
    public TextChunk() : base()
    {
        Content = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TextChunk"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name of the chunk.</param>
    public TextChunk(string name) : base(name)
    {
        Content = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TextChunk"/> class with the specified data and offset.
    /// </summary>
    /// <param name="data">The byte array containing the chunk data.</param>
    /// <param name="offset">The offset within the byte array where the chunk starts.</param>
    public TextChunk(byte[] data, int offset) : base(data, offset)
    {
        Content = Helpers.ReadString(data, offset + 8, Length);
        SkipZeroBytes(data, offset + 8 + Length);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TextChunk"/> class with the specified name and content.
    /// </summary>
    /// <param name="name">The name of the chunk.</param>
    /// <param name="content">The content of the text chunk.</param>
    public TextChunk(string name, string content) : base(name)
    {
        Content = content;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Returns a string that represents the current text chunk.
    /// </summary>
    /// <returns>A string that represents the current text chunk.</returns>
    public override string ToString()
    {
        string ret = base.ToString();
        if (Name == "AUTH" || Name == "ANNO" || Name == "(c) ")
        {
            ret += $"\t{Content}";
        }
        return ret;
    }

    /// <summary>
    /// Exports the content of the text chunk to the specified file.
    /// </summary>
    /// <param name="filename">The name of the file to export the content to.</param>
    public override void Export(string filename) => File.WriteAllText(filename, Content);

    /// <summary>
    /// Writes the content of the text chunk to the specified byte array at the given offset.
    /// </summary>
    /// <param name="data">The byte array to write the content to.</param>
    /// <param name="offset">The offset within the byte array where the content should be written.</param>
    public override void Write(byte[] data, int offset)
    {
        if (Helpers.IsOdd(Content.Length))
        {
            Content += '\0';
        }
        base.Write(data, offset);
        Helpers.WriteString(data, offset + 8, Content);
    }

    /// <summary>
    /// Determines whether the text chunk is a resource.
    /// </summary>
    /// <returns><c>true</c> if the text chunk is a resource; otherwise, <c>false</c>.</returns>
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

    /// <summary>
    /// Gets the file extension for the text chunk based on its name.
    /// </summary>
    /// <returns>The file extension for the text chunk.</returns>
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

    /// <summary>
    /// Gets the resource type of the chunk based on its name.
    /// </summary>
    /// <returns>The resource type as a string.</returns>
    public override string ResourceType() => "Text";
    #endregion
}
