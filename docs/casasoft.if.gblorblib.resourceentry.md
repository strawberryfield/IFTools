# ResourceEntry

Namespace: Casasoft.IF.GBlorbLib

Represents a resource entry in the GBlorb library.

```csharp
public class ResourceEntry
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ResourceEntry](./casasoft.if.gblorblib.resourceentry)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **Type**

Gets or sets the type of the resource.

```csharp
public string Type;
```

### **Number**

Gets or sets the number of the resource.

```csharp
public int Number;
```

### **Start**

Gets or sets the start position of the resource.

```csharp
public int Start;
```

## Constructors

### **ResourceEntry()**

Initializes a new instance of the [ResourceEntry](./casasoft.if.gblorblib.resourceentry) class with default values.

```csharp
public ResourceEntry()
```

### **ResourceEntry(String)**

Initializes a new instance of the [ResourceEntry](./casasoft.if.gblorblib.resourceentry) class with the specified type.

```csharp
public ResourceEntry(string type)
```

#### Parameters

`type` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The type of the resource.

### **ResourceEntry(Byte[], Int32)**

Initializes a new instance of the [ResourceEntry](./casasoft.if.gblorblib.resourceentry) class with the specified data and offset.

```csharp
public ResourceEntry(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array containing the resource data.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset in the byte array where the resource data starts.

## Methods

### **ToString()**

Returns a string that represents the current object.

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A string that represents the current object.

### **Write(Byte[], Int32)**

Writes the resource entry data to the specified byte array at the given offset.

```csharp
public void Write(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to write the data to.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset in the byte array where the data should be written.
