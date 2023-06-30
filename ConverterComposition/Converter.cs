using System;
using System.Globalization;
using System.Text;

namespace ConverterComposition
{
    /// <summary>
    /// Converts a real number to string.
    /// </summary>
    public class Converter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Converter"/> class.
        /// </summary>
        /// <param name="dictionaryFactory">Factory of the dictionary with rules of converting.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when dictionary factory is null.</exception>
        public Converter(ICharsDictionaryFactory? dictionaryFactory)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts double number into string.
        /// </summary>
        /// <param name="number">Double number to convert.</param>
        /// <returns>A number string representation.</returns>
        public string Convert(double number)
        {
            throw new NotImplementedException();
        }
    }
}
