# Chunk

Namespace: Casasoft.IF.GBlorbLib

Represents a chunk of data with a name, length, and address.

```csharp
public class Chunk : IChunk
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Chunk](./casasoft.if.gblorblib.chunk)<br>
Implements [IChunk](./casasoft.if.gblorblib.ichunk)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Name**

Gets or sets the name of the chunk.

```csharp
public string Name { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Length**

Gets or sets the length of the chunk.

```csharp
public int Length { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Address**

Gets or sets the address of the chunk.

```csharp
public int Address { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **ResourceID**

Gets or sets the resource ID of the chunk.

```csharp
public int ResourceID { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Constructors

### **Chunk()**

Initializes a new instance of the [Chunk](./casasoft.if.gblorblib.chunk) class with a default name.

```csharp
public Chunk()
```

### **Chunk(String)**

Initializes a new instance of the [Chunk](./casasoft.if.gblorblib.chunk) class with the specified name.

```csharp
public Chunk(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the chunk.

### **Chunk(Byte[], Int32)**

Initializes a new instance of the [Chunk](./casasoft.if.gblorblib.chunk) class with the specified data and offset.

```csharp
public Chunk(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array containing the chunk data.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the chunk starts.

## Methods

### **ToString()**

Returns a string that represents the current chunk.

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A string that represents the current chunk.

### **Write(Byte[], Int32)**

Writes the chunk data to the specified byte array at the given offset.

```csharp
public void Write(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to write the chunk data to.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the chunk data should be written.

### **FillZero(Byte[], Int32)**

Fills the specified byte array with zero at the given offset if the chunk length is odd.

```csharp
public void FillZero(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to fill with zero.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the zero should be written.

### **Export(String)**

Exports the chunk data to the specified file.

```csharp
public void Export(string filename)
```

#### Parameters

`filename` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the file to export the chunk data to.

### **IsResource()**

Determines whether the chunk is a resource.

```csharp
public bool IsResource()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if the chunk is a resource; otherwise, `false`.

### **ResourceType()**

Gets the resource type of the chunk.

```csharp
public string ResourceType()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The resource type as a string, or an empty string if the chunk is not a resource.

### **FileExtension()**

Gets the file extension associated with the chunk.

```csharp
public string FileExtension()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The file extension as a string.

### **SkipZeroBytes(Byte[], Int32)**

Skips zero bytes in the specified byte array starting from the given offset.

```csharp
protected void SkipZeroBytes(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to skip zero bytes in.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array to start skipping zero bytes from.
