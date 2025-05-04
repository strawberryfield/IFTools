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
/// Represents a frontispice chunk in a GBlorb file.
/// </summary>
public class FrontispiceChunk : Chunk
{
    #region Properties
    /// <summary>
    /// Gets or sets the resource number of the frontispice.
    /// </summary>
    public Int32 ResourceNumber { get; set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="FrontispiceChunk"/> class with the default name "Fspc".
    /// </summary>
    public FrontispiceChunk() : base("Fspc")
    {
        ResourceNumber = 1;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FrontispiceChunk"/> class with the specified resource reference.
    /// </summary>
    /// <param name="res">The resource of the frontispice.</param>
    public FrontispiceChunk(Int32 res) : this()
    {
        ResourceNumber = res;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FrontispiceChunk"/> class with the specified data and offset.
    /// </summary>
    /// <param name="data">The byte array containing the frontispice data.</param>
    /// <param name="offset">The offset within the byte array where the frontispice data starts.</param>
    public FrontispiceChunk(byte[] data, int offset) : base(data, offset)
    {
        ResourceNumber = Helpers.ReadInt32(data, offset + 8);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Returns a string that represents the current frontispice.
    /// </summary>
    /// <returns>A string that represents the current frontispice.</returns>
    public override string ToString() => $"{base.ToString()}\tRes Id:{ResourceNumber,3}";

    /// <summary>
    /// Exports the frontispice data to the specified file.
    /// </summary>
    /// <param name="filename">The name of the file to export the frontispice data to.</param>
    public override void Export(string filename) => File.WriteAllText(filename, $"{ResourceNumber}");

    /// <summary>
    /// Writes the frontispice data to the specified byte array at the given offset.
    /// </summary>
    /// <param name="data">The byte array to write the frontispice data to.</param>
    /// <param name="offset">The offset within the byte array where the frontispice data should be written.</param>
    public override void Write(byte[] data, int offset)
    {
        base.Write(data, offset);
        Helpers.WriteInt32(data, offset + 8, ResourceNumber);
    }
    #endregion
}
