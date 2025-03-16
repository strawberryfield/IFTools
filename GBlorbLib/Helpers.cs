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
/// Provides helper methods for reading and writing strings and 32-bit integers.
/// </summary>
public static class Helpers
{
    /// <summary>
    /// Reads an ASCII string from a byte array.
    /// </summary>
    /// <param name="data">The byte array to read from.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="data"/> at which to begin reading.</param>
    /// <param name="length">The number of bytes to read.</param>
    /// <returns>The ASCII string.</returns>
    public static string ReadString(byte[] data, int offset, int length)
    {
        return Encoding.ASCII.GetString(data, offset, length);
    }

    /// <summary>
    /// Reads a 32-bit integer from a byte array.
    /// </summary>
    /// <param name="data">The byte array to read from.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="data"/> at which to begin reading.</param>
    /// <returns>The 32-bit integer.</returns>
    public static Int32 ReadInt32(byte[] data, int offset)
    {
        if (BitConverter.IsLittleEndian)
        {
            byte[] temp = new byte[4];
            data.Skip(offset).Take(4).Reverse().ToArray().CopyTo(temp, 0);
            return BitConverter.ToInt32(temp, 0);
        }
        else
        {
            return BitConverter.ToInt32(data, offset);
        }
    }

    /// <summary>
    /// Writes an ASCII string to a byte array.
    /// </summary>
    /// <param name="data">The byte array to write to.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="data"/> at which to begin writing.</param>
    /// <param name="value">The string value to write.</param>
    public static void WriteString(byte[] data, int offset, string value)
    {
        Encoding.ASCII.GetBytes(value).CopyTo(data, offset);
    }

    /// <summary>
    /// Writes a 32-bit integer to a byte array.
    /// </summary>
    /// <param name="data">The byte array to write to.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="data"/> at which to begin writing.</param>
    /// <param name="value">The 32-bit integer value to write.</param>
    public static void WriteInt32(byte[] data, int offset, Int32 value)
    {
        if (BitConverter.IsLittleEndian)
        {
            BitConverter.GetBytes(value).Reverse().ToArray().CopyTo(data, offset);
        }
        else
        {
            BitConverter.GetBytes(value).CopyTo(data, offset);
        }
    }
}
