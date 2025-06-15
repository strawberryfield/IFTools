# Header

Namespace: Casasoft.IF.GBlorbLib

Represents the header chunk of a GBlorb file.

```csharp
public class Header : Chunk, IChunk
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Chunk](./casasoft.if.gblorblib.chunk) → [Header](./casasoft.if.gblorblib.header)<br>
Implements [IChunk](./casasoft.if.gblorblib.ichunk)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **Type**

Gets or sets the type of the header.

```csharp
public string Type;
```

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

### **Header()**

Initializes a new instance of the [Header](./casasoft.if.gblorblib.header) class with default values.

```csharp
public Header()
```

### **Header(Byte[])**

Initializes a new instance of the [Header](./casasoft.if.gblorblib.header) class with the specified data.

```csharp
public Header(Byte[] data)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array containing the header data.

### **Header(List&lt;IChunk&gt;, ResourceIndex)**

Initializes a new instance of the [Header](./casasoft.if.gblorblib.header) class using a list of chunks and a resource index.

```csharp
public Header(List<IChunk> chunks, ResourceIndex resourceIndex)
```

#### Parameters

`chunks` [List&lt;IChunk&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
The list of chunks to include in the header.

`resourceIndex` [ResourceIndex](./casasoft.if.gblorblib.resourceindex)<br>
The resource index containing metadata about the resources.

## Methods

### **Write(Byte[], Int32)**

Writes the header data to the specified byte array at the given offset.

```csharp
public void Write(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to write the header data to.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the header data should be written.
