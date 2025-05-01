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
/// Represents a GBlorb file format, which is used for packaging resources for interactive fiction games.
/// <see cref="https://github.com/iftechfoundation/ifarchive-if-specs/blob/main/Blorb-Spec.md"/>
/// </summary>
public class GBlorb
{
    #region Properties
    /// <summary>
    /// Gets or sets the raw data of the GBlorb file.
    /// </summary>
    protected byte[] Data;

    /// <summary>
    /// Gets or sets the header of the GBlorb file.
    /// </summary>
    public Header Header { get; protected set; }

    /// <summary>
    /// Gets or sets the resource index of the GBlorb file.
    /// </summary>
    public ResourceIndex ResourceIndex { get; protected set; }

    /// <summary>
    /// Gets or sets the list of chunks in the GBlorb file.
    /// </summary>
    public List<IChunk> Chunks { get; protected set;}
    #endregion

    #region Constructors    
    /// <summary>
    /// Initializes a new instance of the <see cref="GBlorb"/> class.
    /// </summary>
    public GBlorb()
    {
        Header = new();
        ResourceIndex = new();
        Chunks = new();
        Data = Array.Empty<byte>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GBlorb"/> class from the specified file.
    /// </summary>
    /// <param name="filename">The name of the file to read the GBlorb data from.</param>
    public GBlorb(string filename)
    {
        Data = File.ReadAllBytes(filename);
        Header = new(Data);
        ResourceIndex = new(Data, 12);
        Chunks = new();

        for (int offset = 12 + 8 + ResourceIndex.Length; offset < Data.Length;)
        {
            IChunk chunk = ChunkFactory.CreateChunk(Data, offset);
            chunk.ResourceID = ResourceIndex.GetResourceNumberByAddress(offset);
            Chunks.Add(chunk);
            offset += 8 + chunk.Length;
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Returns a string that represents the current GBlorb object.
    /// </summary>
    /// <returns>A string that represents the current GBlorb object.</returns>
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(Header.ToString());
        sb.AppendLine(ResourceIndex.ToString());
        foreach (IChunk chunk in Chunks)
        {
            sb.AppendLine(chunk.ToString());
        }
        return sb.ToString();
    }

    /// <summary>
    /// Exports the chunks of the GBlorb file to the specified path.
    /// </summary>
    /// <param name="path">The path to export the chunks to.</param>
    public void Export(string path)
    {
        foreach (IChunk chunk in Chunks)
        {
            if (chunk.Address > 0)
            {
                string filename = string.Empty;
                ResourceEntry? entry = ResourceIndex.ResourcesEntries.FirstOrDefault(e => e.Start == chunk.Address);
                if (entry != null)
                {
                    filename = Path.Combine(path, $"{entry.Type}_{entry.Number}{chunk.FileExtension()}");
                    chunk.Export(filename);
                }
            }
        }

        IChunk? IFmd = Chunks.FirstOrDefault(c => c.Name == "IFmd");
        if (IFmd != null)
        {
            IFmd.Export(Path.Combine(path, "IFmd.xml"));
        }
    }

    /// <summary>
    /// Writes the GBlorb data, including the header, resource index, and chunks, to the specified file.
    /// </summary>
    /// <param name="filename">The name of the file to write the GBlorb data to.</param>
    public void Write(string filename)
    {
        ResourceIndex = new(GetResourceChunks());
        Header = new(Chunks, ResourceIndex);
        Data = new byte[Header.Length + 8];

        Header.Write(Data, 0);
        ResourceIndex.Write(Data, 12);
        int offset = 12 + 8 + ResourceIndex.Length;
        foreach (IChunk chunk in Chunks)
        {
            chunk.Write(Data, offset);
            offset += 8 + chunk.Length;
        }

        File.WriteAllBytes(filename, Data);
    }

    /// <summary>
    /// Gets the list of resource chunks from the GBlorb file.
    /// </summary>
    /// <returns>A list of chunks that are identified as resources.</returns>
    public List<IChunk> GetResourceChunks() => Chunks.Where(c => c.IsResource() == true).ToList();

    /// <summary>
    /// Gets the list of optional chunks from the GBlorb file.
    /// </summary>
    /// <returns>A list of chunks that are not identified as resources.</returns>
    public List<IChunk> GetOptionalChunks() => Chunks.Where(c => c.IsResource() == false).ToList();

    /// <summary>
    /// Retrieves a chunk by its type and resource number.
    /// </summary>
    /// <param name="type">The type of the chunk.</param>
    /// <param name="resourceNumber">The resource number of the chunk.</param>
    /// <returns>The chunk matching the specified type and resource number, or null if not found.</returns>
    public IChunk? GetChunkByTypeAndResourceNumber(string type, int resourceNumber) =>
        Chunks.FirstOrDefault(c => c.Name == type && c.ResourceID == resourceNumber);

    /// <summary>
    /// Retrieves a chunk by its type.
    /// </summary>
    /// <param name="type">The type of the chunk to retrieve.</param>
    /// <returns>The chunk matching the specified type, or null if not found.</returns>
    public IChunk? GetChunkByType(string type) => Chunks.FirstOrDefault(c => c.Name == type);
    #endregion
}
