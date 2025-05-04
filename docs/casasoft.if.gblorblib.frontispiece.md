# Frontispiece

Namespace: Casasoft.IF.GBlorbLib

Represents a frontispiece chunk in a GBlorb file.

```csharp
public class Frontispiece : Chunk, IChunk
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Chunk](./casasoft.if.gblorblib.chunk) → [Frontispiece](./casasoft.if.gblorblib.frontispiece)<br>
Implements [IChunk](./casasoft.if.gblorblib.ichunk)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **ResourceNumber**

Gets or sets the resource number of the frontispiece.

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

### **Frontispiece()**

Initializes a new instance of the [Frontispiece](./casasoft.if.gblorblib.frontispiece) class with the default name "Fspc".

```csharp
public Frontispiece()
```

### **Frontispiece(String)**

Initializes a new instance of the [Frontispiece](./casasoft.if.gblorblib.frontispiece) class with the specified name.

```csharp
public Frontispiece(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the frontispiece chunk.

### **Frontispiece(Byte[], Int32)**

Initializes a new instance of the [Frontispiece](./casasoft.if.gblorblib.frontispiece) class with the specified data and offset.

```csharp
public Frontispiece(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array containing the frontispiece data.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the frontispiece data starts.

## Methods

### **ToString()**

Returns a string that represents the current frontispiece.

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A string that represents the current frontispiece.

### **Export(String)**

Exports the frontispiece data to the specified file.

```csharp
public void Export(string filename)
```

#### Parameters

`filename` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the file to export the frontispiece data to.

### **Write(Byte[], Int32)**

Writes the frontispiece data to the specified byte array at the given offset.

```csharp
public void Write(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to write the frontispiece data to.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the frontispiece data should be written.
