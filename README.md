# IFTools

IFTools is a collection of tools for working with Interactive Fiction (IF) games, particularly those created with Inform 7. The tools are designed to help with various tasks such as extracting text from game files and analyzing game data.

## Features

- Parse GBlorb files to extract headers, resource indices, and chunks.
- Export individual chunks to files.
- Add or update optional text chunks (e.g., author, copyright, annotations).
- Write modified GBlorb files back to disk.

## Projects

- **GBlorbLib**: A .NET library for working with GBlorb files. Available as a NuGet package.
- **GBlorbExtract**: A command-line tool for extracting text and resources from GBlorb files.
- **GBlorbEd**: A command-line tool for editing GBlorb files, including adding or updating optional text chunks.

## Documentation

- [Online documentation on GitHub Pages](https://strawberryfield.github.io/IFTools/)
  
## Dependencies

- **.NET 8**
- **Mono.Options**: Used for command-line option parsing in related tools.

## Contributing

Contributions are welcome! Feel free to submit issues or pull requests on this [GitHub repository](https://github.com/strawberryfield/IFTools).

## License

This project is licensed under the GNU Affero General Public License v3.0. See the [LICENSE](https://www.gnu.org/licenses/agpl-3.0.html) file for details.
