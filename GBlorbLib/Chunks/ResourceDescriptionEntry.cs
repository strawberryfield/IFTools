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

namespace Casasoft.IF.GBlorbLib
{
    /// <summary>
    /// Represents a resource description entry in the GBlorb library.
    /// </summary>
    public class ResourceDescriptionEntry
    {
        #region Properties
        /// <summary>
        /// Gets or sets the type of the resource.
        /// </summary>
        public string Type;

        /// <summary>
        /// Gets or sets the number of the resource.
        /// </summary>
        public Int32 Number;

        /// <summary>
        /// Gets or sets the length of the resource description.
        /// </summary>
        public Int32 Length;

        /// <summary>
        /// Gets or sets the description of the resource.
        /// </summary>
        public string Description;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceDescriptionEntry"/> class with default values.
        /// </summary>
        public ResourceDescriptionEntry() : this(new string(' ', 4))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceDescriptionEntry"/> class with the specified type.
        /// </summary>
        /// <param name="type">The type of the resource.</param>
        public ResourceDescriptionEntry(string type)
        {
            Type = type;
            Number = 0;
            Length = 0;
            Description = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceDescriptionEntry"/> class with the specified data and offset.
        /// </summary>
        /// <param name="data">The byte array containing the resource data.</param>
        /// <param name="offset">The offset within the byte array where the resource data starts.</param>
        public ResourceDescriptionEntry(byte[] data, Int32 offset)
        {
            Type = Helpers.ReadString(data, offset, 4);
            Number = Helpers.ReadInt32(data, offset + 4);
            Length = Helpers.ReadInt32(data, offset + 8);
            Description = Helpers.ReadString(data, offset + 12, Length);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => $"- {Type} idx:{Number,3}\t{Description}";

        /// <summary>
        /// Writes the resource description entry to the specified byte array at the given offset.
        /// </summary>
        /// <param name="data">The byte array to write to.</param>
        /// <param name="offset">The offset within the byte array where the resource data should be written.</param>
        public void Write(byte[] data, Int32 offset)
        {
            Helpers.WriteString(data, offset, Type);
            Helpers.WriteInt32(data, offset + 4, Number);
            Helpers.WriteInt32(data, offset + 8, Length);
            Helpers.WriteString(data, offset + 12, Description);
        }
        #endregion
    }
}
