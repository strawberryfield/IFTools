# ResourceIndex

Namespace: Casasoft.IF.GBlorbLib

Represents an index of resources within a chunk.

```csharp
public class ResourceIndex : Chunk, IChunk
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Chunk](./casasoft.if.gblorblib.chunk) → [ResourceIndex](./casasoft.if.gblorblib.resourceindex)<br>
Implements [IChunk](./casasoft.if.gblorblib.ichunk)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **TotalResourcesCount**

Gets or sets the total number of resources.

```csharp
public int TotalResourcesCount;
```

### **ResourcesEntries**

Gets or sets the list of resource entries.

```csharp
public List<ResourceEntry> ResourcesEntries;
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

### **ResourceIndex()**

Initializes a new instance of the [ResourceIndex](./casasoft.if.gblorblib.resourceindex) class with a default name.

```csharp
public ResourceIndex()
```

### **ResourceIndex(Byte[], Int32)**

Initializes a new instance of the [ResourceIndex](./casasoft.if.gblorblib.resourceindex) class with the specified data and offset.

```csharp
public ResourceIndex(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array containing the resource index data.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the resource index starts.

### **ResourceIndex(List&lt;IChunk&gt;)**

Initializes a new instance of the [ResourceIndex](./casasoft.if.gblorblib.resourceindex) class using a list of chunks.

```csharp
public ResourceIndex(List<IChunk> chunks)
```

#### Parameters

`chunks` [List&lt;IChunk&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
The list of chunks to include in the resource index.

## Methods

### **ToString()**

Returns a string that represents the current resource index.

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A string that represents the current resource index.

### **Write(Byte[], Int32)**

Writes the resource index data to the specified byte array at the given offset.

```csharp
public void Write(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to write the resource index data to.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the resource index data should be written.

### **GetResourceNumberByAddress(Int32)**

Gets the resource number by its address.

```csharp
public int GetResourceNumberByAddress(int address)
```

#### Parameters

`address` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The address of the resource.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The resource number if found; otherwise, -1.
