# ResourceDescriptionEntry

Namespace: Casasoft.IF.GBlorbLib

Represents a resource description entry in the GBlorb library.

```csharp
public class ResourceDescriptionEntry
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ResourceDescriptionEntry](./casasoft.if.gblorblib.resourcedescriptionentry)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **Type**

Gets or sets the type of the resource.

```csharp
public string Type;
```

### **Number**

Gets or sets the number of the resource.

```csharp
public int Number;
```

### **Length**

Gets or sets the length of the resource description.

```csharp
public int Length;
```

### **Description**

Gets or sets the description of the resource.

```csharp
public string Description;
```

## Constructors

### **ResourceDescriptionEntry()**

Initializes a new instance of the [ResourceDescriptionEntry](./casasoft.if.gblorblib.resourcedescriptionentry) class with default values.

```csharp
public ResourceDescriptionEntry()
```

### **ResourceDescriptionEntry(String)**

Initializes a new instance of the [ResourceDescriptionEntry](./casasoft.if.gblorblib.resourcedescriptionentry) class with the specified type.

```csharp
public ResourceDescriptionEntry(string type)
```

#### Parameters

`type` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The type of the resource.

### **ResourceDescriptionEntry(Byte[], Int32)**

Initializes a new instance of the [ResourceDescriptionEntry](./casasoft.if.gblorblib.resourcedescriptionentry) class with the specified data and offset.

```csharp
public ResourceDescriptionEntry(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array containing the resource data.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the resource data starts.

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

Writes the resource description entry to the specified byte array at the given offset.

```csharp
public void Write(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array to write to.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the byte array where the resource data should be written.
