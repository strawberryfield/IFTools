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
/// The ChunkFactory class is responsible for creating instances of different types of chunks
/// based on the provided data and offset. It reads the chunk name from the data and returns
/// an appropriate chunk object.
/// </summary>
public static class ChunkFactory
{
    /// <summary>
    /// Creates an instance of a chunk based on the provided data and offset.
    /// </summary>
    /// <param name="data">The byte array containing the chunk data.</param>
    /// <param name="offset">The offset within the data where the chunk starts.</param>
    /// <returns>An instance of a class that implements the IChunk interface.</returns>
    public static IChunk CreateChunk(byte[] data, int offset)
    {
        string name = Helpers.ReadString(data, offset, 4);
        switch (name)
        {
            case "FORM":
                return new Header(data);
            case "RIdx":
                return new ResourceIndex(data, offset);
            case "RDes":
                return new ResourceDescriptionIndex(data, offset);
            case "Fspc":
                return new FrontispiceChunk(data, offset);

            case "TEXT":
            case "IFmd":
            case "AUTH":
            case "ANNO":
            case "(c) ":
                return new TextChunk(data, offset);

            case "BINA":
            case "JPEG":
            case "PNG ":
            case "OGGV":
            case "AIFF":
            case "MIDI":
            case "MOD ":
            case "ZCOD":
            case "GLUL":
                return new BinaryChunk(data, offset);

            default:
                return new Chunk(data, offset);
        }
    }
}
