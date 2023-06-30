namespace ConverterComposition
{
    /// <summary>
    /// Interface presents the factory of the dictionary of the char correspondences of the number to their word analogs in given language.
    /// </summary>
    public interface ICharsDictionaryFactory
    {
        /// <summary>
        /// Create the dictionary of the chars correspondences.
        /// </summary>
        /// <returns>The dictionary of the chars correspondences.</returns>
        CharsDictionary CreateDictionary();
    }
}
