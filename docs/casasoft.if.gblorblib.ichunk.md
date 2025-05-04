# IChunk

Namespace: Casasoft.IF.GBlorbLib

Represents a chunk of data with a name, length, and address.

```csharp
public interface IChunk
```

Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute)

## Properties

### **Name**

Gets or sets the name of the chunk.

```csharp
public abstract string Name { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Length**

Gets or sets the length of the chunk.

```csharp
public abstract int Length { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Address**

Gets or sets the address of the chunk.

```csharp
public abstract int Address { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **ResourceID**

Gets or sets the resource ID of the chunk.

```csharp
public abstract int ResourceID { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Methods

### **Write(Byte[], Int32)**

Writes data to the chunk at the specified offset.

```csharp
void Write(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The data to write.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset at which to start writing.

### **FillZero(Byte[], Int32)**

Fills the specified byte array with zero at the given offset if the chunk length is odd.

```csharp
void FillZero(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to fill with zero.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the zero should be written.

### **Export(String)**

Exports the chunk to a file.

```csharp
void Export(string filename)
```

#### Parameters

`filename` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the file to export to.

### **IsResource()**

Determines whether the chunk is a resource.

```csharp
bool IsResource()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
True if the chunk is a resource; otherwise, false.

### **ResourceType()**

Gets the resource type of the chunk.

```csharp
string ResourceType()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Type of the resource in the chunk, empty if the chunk is not a resorce

### **FileExtension()**

Gets the file extension associated with the chunk.

```csharp
string FileExtension()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The file extension as a string.
