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
/// Represents the header chunk of a GBlorb file.
/// </summary>
public class Header : Chunk
{
    #region Properties
    /// <summary>
    /// Gets or sets the type of the header.
    /// </summary>
    public String Type;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Header"/> class with default values.
    /// </summary>
    public Header() : base("FORM")
    {
        Type = "IFRS";
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Header"/> class with the specified data.
    /// </summary>
    /// <param name="data">The byte array containing the header data.</param>
    public Header(byte[] data) : base(data, 0)
    {
        Type = Helpers.ReadString(data, 8, 4);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Writes the header data to the specified byte array at the given offset.
    /// </summary>
    /// <param name="data">The byte array to write the header data to.</param>
    /// <param name="offset">The offset within the byte array where the header data should be written.</param>
    public override void Write(byte[] data, int offset)
    {
        base.Write(data, offset);
        Helpers.WriteString(data, offset + 8, Type);
    }
    #endregion
}
