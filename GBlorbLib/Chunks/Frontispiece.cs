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
/// Represents a frontispiece chunk in a GBlorb file.
/// </summary>
public class Frontispiece : Chunk
{
    #region Properties
    /// <summary>
    /// Gets or sets the resource number of the frontispiece.
    /// </summary>
    public Int32 ResourceNumber { get; set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Frontispiece"/> class with the default name "Fspc".
    /// </summary>
    public Frontispiece() : this("Fspc")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Frontispiece"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name of the frontispiece chunk.</param>
    public Frontispiece(string name) : base(name)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Frontispiece"/> class with the specified data and offset.
    /// </summary>
    /// <param name="data">The byte array containing the frontispiece data.</param>
    /// <param name="offset">The offset within the byte array where the frontispiece data starts.</param>
    public Frontispiece(byte[] data, int offset) : base(data, offset)
    {
        ResourceNumber = Helpers.ReadInt32(data, offset + 8);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Returns a string that represents the current frontispiece.
    /// </summary>
    /// <returns>A string that represents the current frontispiece.</returns>
    public override string ToString() => $"{base.ToString()}\tRes Id:{ResourceNumber,3}";

    /// <summary>
    /// Exports the frontispiece data to the specified file.
    /// </summary>
    /// <param name="filename">The name of the file to export the frontispiece data to.</param>
    public override void Export(string filename) => File.WriteAllText(filename, $"{ResourceNumber}");

    /// <summary>
    /// Writes the frontispiece data to the specified byte array at the given offset.
    /// </summary>
    /// <param name="data">The byte array to write the frontispiece data to.</param>
    /// <param name="offset">The offset within the byte array where the frontispiece data should be written.</param>
    public override void Write(byte[] data, int offset)
    {
        base.Write(data, offset);
        Helpers.WriteInt32(data, offset + 8, ResourceNumber);
    }
    #endregion
}
