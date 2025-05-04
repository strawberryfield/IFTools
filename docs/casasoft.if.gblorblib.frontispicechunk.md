# FrontispiceChunk

Namespace: Casasoft.IF.GBlorbLib

Represents a frontispice chunk in a GBlorb file.

```csharp
public class FrontispiceChunk : Chunk, IChunk
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Chunk](./casasoft.if.gblorblib.chunk) → [FrontispiceChunk](./casasoft.if.gblorblib.frontispicechunk)<br>
Implements [IChunk](./casasoft.if.gblorblib.ichunk)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **ResourceNumber**

Gets or sets the resource number of the frontispice.

```csharp
public int ResourceNumber { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

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

### **FrontispiceChunk()**

Initializes a new instance of the [FrontispiceChunk](./casasoft.if.gblorblib.frontispicechunk) class with the default name "Fspc".

```csharp
public FrontispiceChunk()
```

### **FrontispiceChunk(Int32)**

Initializes a new instance of the [FrontispiceChunk](./casasoft.if.gblorblib.frontispicechunk) class with the specified resource reference.

```csharp
public FrontispiceChunk(int res)
```

#### Parameters

`res` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The resource of the frontispice.

### **FrontispiceChunk(Byte[], Int32)**

Initializes a new instance of the [FrontispiceChunk](./casasoft.if.gblorblib.frontispicechunk) class with the specified data and offset.

```csharp
public FrontispiceChunk(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array containing the frontispice data.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the frontispice data starts.

## Methods

### **ToString()**

Returns a string that represents the current frontispice.

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A string that represents the current frontispice.

### **Export(String)**

Exports the frontispice data to the specified file.

```csharp
public void Export(string filename)
```

#### Parameters

`filename` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the file to export the frontispice data to.

### **Write(Byte[], Int32)**

Writes the frontispice data to the specified byte array at the given offset.

```csharp
public void Write(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to write the frontispice data to.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the frontispice data should be written.
