﻿// copyright (c) 2025 Roberto Ceccarelli - Casasoft
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
    public Header Header;

    /// <summary>
    /// Gets or sets the resource index of the GBlorb file.
    /// </summary>
    public ResourceIndex ResourceIndex;

    /// <summary>
    /// Gets or sets the list of chunks in the GBlorb file.
    /// </summary>
    public List<IChunk> Chunks;
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
    #endregion
}
