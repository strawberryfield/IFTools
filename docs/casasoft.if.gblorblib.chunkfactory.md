# ChunkFactory

Namespace: Casasoft.IF.GBlorbLib

The ChunkFactory class is responsible for creating instances of different types of chunks
 based on the provided data and offset. It reads the chunk name from the data and returns
 an appropriate chunk object.

```csharp
public static class ChunkFactory
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ChunkFactory](./casasoft.if.gblorblib.chunkfactory)

## Methods

### **CreateChunk(Byte[], Int32)**

Creates an instance of a chunk based on the provided data and offset.

```csharp
public static IChunk CreateChunk(Byte[] data, int offset)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte array containing the chunk data.

`offset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The offset within the data where the chunk starts.

#### Returns

[IChunk](./casasoft.if.gblorblib.ichunk)<br>
An instance of a class that implements the IChunk interface.
