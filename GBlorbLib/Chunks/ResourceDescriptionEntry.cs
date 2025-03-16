namespace Casasoft.IF.GBlorbLib
{
    public class ResourceDescriptionEntry
    {
        #region Properties
        public string Type;
        public Int32 Number;
        public Int32 Length;
        public string Description;
        #endregion

        #region Constructors
        public ResourceDescriptionEntry() : this(new string(' ', 4))
        { }

        public ResourceDescriptionEntry(string type)
        {
            Type = type;
            Number = 0;
            Length = 0;
            Description = string.Empty;
        }

        public ResourceDescriptionEntry(byte[] data, Int32 offset)
        {
            Type = Helpers.ReadString(data, offset, 4);
            Number = Helpers.ReadInt32(data, offset + 4);
            Length = Helpers.ReadInt32(data, offset + 8);
            Description = Helpers.ReadString(data, offset + 12, Length);
        }
        #endregion

        #region Methods
        public override string ToString() => $"- {Type} idx:{Number,3}\t{Description}";

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
