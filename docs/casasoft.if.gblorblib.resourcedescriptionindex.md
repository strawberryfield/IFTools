# ResourceDescriptionIndex

Namespace: Casasoft.IF.GBlorbLib

Represents an index of resource descriptions within a chunk.

```csharp
public class ResourceDescriptionIndex : Chunk, IChunk
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Chunk](./casasoft.if.gblorblib.chunk) → [ResourceDescriptionIndex](./casasoft.if.gblorblib.resourcedescriptionindex)<br>
Implements [IChunk](./casasoft.if.gblorblib.ichunk)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **TotalResourcesCount**

Gets or sets the total number of resources.

```csharp
public int TotalResourcesCount;
```

### **DescriptionsEntries**

Gets or sets the list of resource description entries.

```csharp
public List<ResourceDescriptionEntry> DescriptionsEntries;
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

### **ResourceDescriptionIndex()**

Initializes a new instance of the [ResourceDescriptionIndex](./casasoft.if.gblorblib.resourcedescriptionindex) class with a default name.

```csharp
public ResourceDescriptionIndex()
```

### **ResourceDescriptionIndex(Byte[], Int32)**

Initializes a new instance of the [ResourceDescriptionIndex](./casasoft.if.gblorblib.resourcedescriptionindex) class with the specified data and offset.

```csharp
public ResourceDescriptionIndex(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array containing the chunk data.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the chunk starts.

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

Writes the resource description index data to the specified byte array at the given offset.

```csharp
public void Write(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to write the data to.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the data should be written.
