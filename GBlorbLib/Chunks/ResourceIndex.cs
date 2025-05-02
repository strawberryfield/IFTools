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
/// Represents an index of resources within a chunk.
/// </summary>
public class ResourceIndex : Chunk
{
    #region Properties
    /// <summary>
    /// Gets or sets the total number of resources.
    /// </summary>
    public Int32 TotalResourcesCount;

    /// <summary>
    /// Gets or sets the list of resource entries.
    /// </summary>
    public List<ResourceEntry> ResourcesEntries;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceIndex"/> class with a default name.
    /// </summary>
    public ResourceIndex() : base("RIdx")
    {
        TotalResourcesCount = 0;
        ResourcesEntries = new();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceIndex"/> class with the specified data and offset.
    /// </summary>
    /// <param name="data">The byte array containing the resource index data.</param>
    /// <param name="offset">The offset within the byte array where the resource index starts.</param>
    public ResourceIndex(byte[] data, int offset) : base(data, offset)
    {
        TotalResourcesCount = Helpers.ReadInt32(data, offset + 8);

        Int32 currentOffset = offset + 12;
        ResourcesEntries = new();
        for (Int32 i = 0; i < TotalResourcesCount; i++)
        {
            ResourcesEntries.Add(new ResourceEntry(data, currentOffset));
            currentOffset += 12;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceIndex"/> class using a list of chunks.
    /// </summary>
    /// <param name="chunks">The list of chunks to include in the resource index.</param>
    public ResourceIndex(List<IChunk> chunks) : base("RIdx")
    {
        TotalResourcesCount = chunks.Count;
        Length = TotalResourcesCount * 12 + 4;
        ResourcesEntries = new();
        int progressiveAddress = 12 + Length+8;
        foreach (IChunk chunk in chunks)
        {
            ResourceEntry entry = new(chunk.ResourceType())
            {
                Number = chunk.ResourceID,
                Start = progressiveAddress
            };
            ResourcesEntries.Add(entry);

            progressiveAddress += (chunk.Length+8);
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Returns a string that represents the current resource index.
    /// </summary>
    /// <returns>A string that represents the current resource index.</returns>
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ToString());
        foreach (ResourceEntry entry in ResourcesEntries)
        {
            sb.AppendLine(entry.ToString());
        }
        return sb.ToString();
    }

    /// <summary>
    /// Writes the resource index data to the specified byte array at the given offset.
    /// </summary>
    /// <param name="data">The byte array to write the resource index data to.</param>
    /// <param name="offset">The offset within the byte array where the resource index data should be written.</param>
    public override void Write(byte[] data, int offset)
    {
        base.Write(data, offset);
        Helpers.WriteInt32(data, offset + 8, TotalResourcesCount);
        Int32 currentOffset = offset + 12;
        foreach (ResourceEntry entry in ResourcesEntries)
        {
            entry.Write(data, currentOffset);
            currentOffset += 12;
        }
    }

    public Int32 GetResourceNumberByAddress(Int32 address) => ResourcesEntries.FirstOrDefault(e => e.Start == address)?.Number ?? -1;
    #endregion
}
