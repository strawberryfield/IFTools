# GBlorb

Namespace: Casasoft.IF.GBlorbLib

Represents a GBlorb file format, which is used for packaging resources for interactive fiction games.

```csharp
public class GBlorb
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [GBlorb](./casasoft.if.gblorblib.gblorb)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **Data**

Gets or sets the raw data of the GBlorb file.

```csharp
protected Byte[] Data;
```

## Properties

### **Header**

Gets or sets the header of the GBlorb file.

```csharp
public Header Header { get; protected set; }
```

#### Property Value

[Header](./casasoft.if.gblorblib.header)<br>

### **ResourceIndex**

Gets or sets the resource index of the GBlorb file.

```csharp
public ResourceIndex ResourceIndex { get; protected set; }
```

#### Property Value

[ResourceIndex](./casasoft.if.gblorblib.resourceindex)<br>

### **Chunks**

Gets or sets the list of chunks in the GBlorb file.

```csharp
public List<IChunk> Chunks { get; protected set; }
```

#### Property Value

[List&lt;IChunk&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

## Constructors

### **GBlorb()**

Initializes a new instance of the [GBlorb](./casasoft.if.gblorblib.gblorb) class.

```csharp
public GBlorb()
```

### **GBlorb(String)**

Initializes a new instance of the [GBlorb](./casasoft.if.gblorblib.gblorb) class from the specified file.

```csharp
public GBlorb(string filename)
```

#### Parameters

`filename` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the file to read the GBlorb data from.

## Methods

### **ToString()**

Returns a string that represents the current GBlorb object.

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A string that represents the current GBlorb object.

### **Export(String)**

Exports the chunks of the GBlorb file to the specified path.

```csharp
public void Export(string path)
```

#### Parameters

`path` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The path to export the chunks to.

### **Write(String)**

Writes the GBlorb data, including the header, resource index, and chunks, to the specified file.

```csharp
public void Write(string filename)
```

#### Parameters

`filename` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the file to write the GBlorb data to.

### **WriteChunkList(Byte[], Int32, List&lt;IChunk&gt;)**

Writes a list of chunks to the specified byte array starting at the given offset.

```csharp
protected static int WriteChunkList(Byte[] data, int offset, List<IChunk> chunks)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to write the chunk data to.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the chunk data should be written.

`chunks` [List&lt;IChunk&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
The list of chunks to write to the byte array.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The updated offset after writing all chunks.

### **GetResourceChunks()**

Gets the list of resource chunks from the GBlorb file.

```csharp
public List<IChunk> GetResourceChunks()
```

#### Returns

[List&lt;IChunk&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
A list of chunks that are identified as resources.

### **GetOptionalChunks()**

Gets the list of optional chunks from the GBlorb file.

```csharp
public List<IChunk> GetOptionalChunks()
```

#### Returns

[List&lt;IChunk&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
A list of chunks that are not identified as resources.

### **GetChunkByTypeAndResourceNumber(String, Int32)**

Retrieves a chunk by its type and resource number.

```csharp
public IChunk GetChunkByTypeAndResourceNumber(string type, int resourceNumber)
```

#### Parameters

`type` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The type of the chunk.

`resourceNumber` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The resource number of the chunk.

#### Returns

[IChunk](./casasoft.if.gblorblib.ichunk)<br>
The chunk matching the specified type and resource number, or null if not found.

### **GetChunkByType(String)**

Retrieves a chunk by its type.

```csharp
public IChunk GetChunkByType(string type)
```

#### Parameters

`type` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The type of the chunk to retrieve.

#### Returns

[IChunk](./casasoft.if.gblorblib.ichunk)<br>
The chunk matching the specified type, or null if not found.

### **AddUpdateOptionalTextChunk(String, String)**

Adds or updates an optional text chunk in the GBlorb file.

```csharp
public void AddUpdateOptionalTextChunk(string name, string text)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the text chunk.

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The text content to add or update.
