# GBlorbLib

**GBlorbLib** is a .NET library for working with the GBlorb file format, 
which is used to package resources for interactive fiction (IF) games. 
It provides functionality to read, manipulate, and write GBlorb files,
including handling headers, resource indices, and chunks.

## Features

- Parse GBlorb files to extract headers, resource indices, and chunks.
- Export individual chunks to files.
- Add or update optional text chunks (e.g., author, copyright, annotations).
- Write modified GBlorb files back to disk.

## Installation

To use **GBlorbLib** in your project, add a reference to the library. 
If using Visual Studio, you can include the NuGet package.

## Usage

### Reading a GBlorb File

```csharp
using Casasoft.IF.GBlorbLib;

// Load a GBlorb file 
GBlorb blorb = new("path/to/file.gblorb");

// Access header, resource index, and chunks 
Console.WriteLine(blorb.Header); 
Console.WriteLine(blorb.ResourceIndex); 
foreach (var chunk in blorb.Chunks) { Console.WriteLine(chunk); }
```

### Exporting a Chunk
```csharp	
// Export all chunks to a specified directory 
blorb.Export("path/to/export/directory");
```

### Adding/Updating Optional Text Chunks
```csharp	
// Add or update optional text chunks
blorb.AddUpdateOptionalTextChunk("AUTH", "Author Name"); 
blorb.AddUpdateOptionalTextChunk("(c) ", "2025 Author Copyright"); 
blorb.AddUpdateOptionalTextChunk("ANNO", "Annotations or remarks");
```

### Writing a Modified GBlorb File
```csharp
// Save changes to a new GBlorb file 
blorb.Write("path/to/output.gblorb");
```

## Online documentation

For detailed documentation, including API references, visit the [GBlorbLib documentation site](https://strawberryfield.github.io/IFTools/GblorbLib-index).

## Dependencies

- **.NET 8**
- **Mono.Options**: Used for command-line option parsing in related tools.

## Contributing

Contributions are welcome! Feel free to submit issues or pull requests on the [GitHub repository](https://github.com/strawberryfield/IFTools).

## License

This project is licensed under the GNU Affero General Public License v3.0. See the [LICENSE](https://www.gnu.org/licenses/agpl-3.0.html) file for details.

## Acknowledgments

- Developed by Roberto Ceccarelli - Casasoft.
- Based on the [Blorb Specification](https://github.com/iftechfoundation/ifarchive-if-specs/blob/main/Blorb-Spec.md).


