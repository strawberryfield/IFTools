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

    /// <summary>
    /// Gets or sets the resource ID of the chunk.
    /// </summary>
    Int32 ResourceID { get; set; }
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

    /// <summary>
    /// Gets the resource type of the chunk.
    /// </summary>
    /// <returns>Type of the resource in the chunk, empty if the chunk is not a resorce</returns>
    string ResourceType();

    /// <summary>
    /// Gets the file extension associated with the chunk.
    /// </summary>
    /// <returns>The file extension as a string.</returns>
    string FileExtension();
    #endregion
}
