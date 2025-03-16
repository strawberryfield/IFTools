namespace Casasoft.IF.GBlorbLib;

public class ResourceEntry
{
    #region Properties
    public string Type;
    public Int32 Number;
    public Int32 Start;
    #endregion

    #region Constructors
    public ResourceEntry() : this(new string(' ', 4))
    { }

    public ResourceEntry(string type)
    {
        Type = type;
        Number = 0;
        Start = 0;
    }

    public ResourceEntry(byte[] data, Int32 offset)
    {
        Type = Helpers.ReadString(data, offset, 4);
        Number = Helpers.ReadInt32(data, offset + 4);
        Start = Helpers.ReadInt32(data, offset + 8);
    }
    #endregion

    #region Methods
    public override string ToString() => $"- {Type} idx:{Number,3}";

    public void Write(byte[] data, Int32 offset)
    {
        Helpers.WriteString(data, offset, Type);
        Helpers.WriteInt32(data, offset + 4, Number);
        Helpers.WriteInt32(data, offset + 8, Start);
    }
    #endregion
}
