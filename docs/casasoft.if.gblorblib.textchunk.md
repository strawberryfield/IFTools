# TextChunk

Namespace: Casasoft.IF.GBlorbLib

Represents a text chunk in a Blorb file.

```csharp
public class TextChunk : Chunk, IChunk
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Chunk](./casasoft.if.gblorblib.chunk) → [TextChunk](./casasoft.if.gblorblib.textchunk)<br>
Implements [IChunk](./casasoft.if.gblorblib.ichunk)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Content**

Gets or sets the content of the text chunk.

```csharp
public string Content { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

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

### **TextChunk()**

Initializes a new instance of the [TextChunk](./casasoft.if.gblorblib.textchunk) class.

```csharp
public TextChunk()
```

### **TextChunk(String)**

Initializes a new instance of the [TextChunk](./casasoft.if.gblorblib.textchunk) class with the specified name.

```csharp
public TextChunk(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the chunk.

### **TextChunk(Byte[], Int32)**

Initializes a new instance of the [TextChunk](./casasoft.if.gblorblib.textchunk) class with the specified data and offset.

```csharp
public TextChunk(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array containing the chunk data.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the chunk starts.

### **TextChunk(String, String)**

Initializes a new instance of the [TextChunk](./casasoft.if.gblorblib.textchunk) class with the specified name and content.

```csharp
public TextChunk(string name, string content)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the chunk.

`content` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The content of the text chunk.

## Methods

### **ToString()**

Returns a string that represents the current text chunk.

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A string that represents the current text chunk.

### **Export(String)**

Exports the content of the text chunk to the specified file.

```csharp
public void Export(string filename)
```

#### Parameters

`filename` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the file to export the content to.

### **Write(Byte[], Int32)**

Writes the content of the text chunk to the specified byte array at the given offset.

```csharp
public void Write(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to write the content to.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the content should be written.

### **IsResource()**

Determines whether the text chunk is a resource.

```csharp
public bool IsResource()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if the text chunk is a resource; otherwise, `false`.

### **FileExtension()**

Gets the file extension for the text chunk based on its name.

```csharp
public string FileExtension()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The file extension for the text chunk.

### **ResourceType()**

Gets the resource type of the chunk based on its name.

```csharp
public string ResourceType()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The resource type as a string.
