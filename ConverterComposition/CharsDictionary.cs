using System.Collections.Generic;

namespace ConverterComposition
{
    /// <summary>
    /// Presents the dictionary of the char correspondences of the number to their word analogs in given language.
    /// </summary>
    public sealed class CharsDictionary
    {
        /// <summary>
        /// Gets or sets the dictionary of all possible characters.
        /// </summary>
        public IReadOnlyDictionary<Character, string>? Dictionary { get; set; }

        /// <summary>
        /// Gets or sets the language string compliant with RFC 1766. Default value - "en-us".
        /// </summary>
        public string? CultureName { get; set; }
    }
}
