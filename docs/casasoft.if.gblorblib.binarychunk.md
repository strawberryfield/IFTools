# BinaryChunk

Namespace: Casasoft.IF.GBlorbLib

Represents a binary chunk of data.

```csharp
public class BinaryChunk : Chunk, IChunk
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Chunk](./casasoft.if.gblorblib.chunk) → [BinaryChunk](./casasoft.if.gblorblib.binarychunk)<br>
Implements [IChunk](./casasoft.if.gblorblib.ichunk)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Content**

Gets or sets the content of the binary chunk.

```csharp
public Byte[] Content { get; set; }
```

#### Property Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>

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

### **FillerLength**

Gets or sets the filler length of the chunk.

```csharp
public int FillerLength { get; set; }
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

### **BinaryChunk()**

Initializes a new instance of the [BinaryChunk](./casasoft.if.gblorblib.binarychunk) class with a default name.

```csharp
public BinaryChunk()
```

### **BinaryChunk(String)**

Initializes a new instance of the [BinaryChunk](./casasoft.if.gblorblib.binarychunk) class with the specified name.

```csharp
public BinaryChunk(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the binary chunk.

### **BinaryChunk(Byte[], Int32)**

Initializes a new instance of the [BinaryChunk](./casasoft.if.gblorblib.binarychunk) class with the specified data and offset.

```csharp
public BinaryChunk(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array containing the chunk data.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the chunk starts.

## Methods

### **Export(String)**

Exports the binary chunk to the specified file.

```csharp
public void Export(string filename)
```

#### Parameters

`filename` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the file to export to.

### **Write(Byte[], Int32)**

Writes the binary chunk data to the specified byte array at the given offset.

```csharp
public void Write(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to write the chunk data to.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the chunk data should be written.

### **IsResource()**

Determines whether the chunk is a resource.

```csharp
public bool IsResource()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if the chunk is a resource; otherwise, `false`.

### **FileExtension()**

Gets the file extension for the binary chunk based on its name.

```csharp
public string FileExtension()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The file extension for the binary chunk.

### **ResourceType()**

Gets the resource type of the chunk based on its name.

```csharp
public string ResourceType()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Resource type or empty string if unknown
