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

using System.Text;

namespace Casasoft.IF.GBlorbLib;

/// <summary>
/// Represents an index of resource descriptions within a chunk.
/// </summary>
public class ResourceDescriptionIndex : Chunk
{
    #region Properties
    /// <summary>
    /// Gets or sets the total number of resources.
    /// </summary>
    public Int32 TotalResourcesCount;

    /// <summary>
    /// Gets or sets the list of resource description entries.
    /// </summary>
    public List<ResourceDescriptionEntry> DescriptionsEntries;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceDescriptionIndex"/> class with a default name.
    /// </summary>
    public ResourceDescriptionIndex() : base("RDes")
    {
        TotalResourcesCount = 0;
        DescriptionsEntries = new();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceDescriptionIndex"/> class with the specified data and offset.
    /// </summary>
    /// <param name="data">The byte array containing the chunk data.</param>
    /// <param name="offset">The offset within the byte array where the chunk starts.</param>
    public ResourceDescriptionIndex(byte[] data, int offset) : base(data, offset)
    {
        TotalResourcesCount = Helpers.ReadInt32(data, offset + 8);

        Int32 currentOffset = offset + 12;
        DescriptionsEntries = new();
        for (Int32 i = 0; i < TotalResourcesCount; i++)
        {
            ResourceDescriptionEntry entry = new(data, currentOffset);
            DescriptionsEntries.Add(entry);
            currentOffset += 12 + entry.Length;
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ToString());
        foreach (ResourceDescriptionEntry entry in DescriptionsEntries)
        {
            sb.AppendLine(entry.ToString());
        }
        return sb.ToString();
    }

    /// <summary>
    /// Writes the resource description index data to the specified byte array at the given offset.
    /// </summary>
    /// <param name="data">The byte array to write the data to.</param>
    /// <param name="offset">The offset within the byte array where the data should be written.</param>
    public override void Write(byte[] data, int offset)
    {
        base.Write(data, offset);
        Helpers.WriteInt32(data, offset + 8, TotalResourcesCount);
        Int32 currentOffset = offset + 12;
        foreach (ResourceDescriptionEntry entry in DescriptionsEntries)
        {
            entry.Write(data, currentOffset);
            currentOffset += 12 + entry.Length;
        }
    }
    #endregion
}
