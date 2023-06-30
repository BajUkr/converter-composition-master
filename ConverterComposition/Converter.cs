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
        private readonly CharsDictionary charsDictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="Converter"/> class.
        /// </summary>
        /// <param name="dictionaryFactory">Factory of the dictionary with rules of converting.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when dictionary factory is null.</exception>
        public Converter(ICharsDictionaryFactory? dictionaryFactory)
        {
            if (dictionaryFactory == null)
            {
                throw new ArgumentNullException(nameof(dictionaryFactory));
            }

            this.charsDictionary = dictionaryFactory.CreateDictionary();
        }

        /// <summary>
        /// Converts double number into string.
        /// </summary>
        /// <param name="number">Double number to convert.</param>
        /// <returns>A number string representation.</returns>
        public string Convert(double number)
        {
            if (this.charsDictionary.Dictionary == null)
            {
                throw new InvalidOperationException("CharsDictionary.Dictionary is null.");
            }

            if (number == double.Epsilon)
            {
                if (this.charsDictionary.Dictionary.TryGetValue(Character.Epsilon, out var word))
                {
                    return word;
                }
                else
                {
                    throw new InvalidOperationException("Character Epsilon not found in CharsDictionary.");
                }
            }

            if (double.IsNegativeInfinity(number))
            {
                if (this.charsDictionary.Dictionary.TryGetValue(Character.NegativeInfinity, out var word))
                {
                    return word;
                }
                else
                {
                    throw new InvalidOperationException("Character NegativeInfinity not found in CharsDictionary.");
                }
            }

            if (double.IsNaN(number))
            {
                if (this.charsDictionary.Dictionary.TryGetValue(Character.NaN, out var word))
                {
                    return word;
                }
                else
                {
                    throw new InvalidOperationException("Character NaN not found in CharsDictionary.");
                }
            }

            var numberString = number.ToString(CultureInfo.CreateSpecificCulture(this.charsDictionary.CultureName ?? "en-US"));
            var stringBuilder = new StringBuilder();

            foreach (var c in numberString)
            {
                if (this.charsDictionary.Dictionary.TryGetValue(GetCharacterFromChar(c), out var word))
                {
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append(' '); // Add a space between words
                    }

                    stringBuilder.Append(word);
                }
                else
                {
                    throw new InvalidOperationException($"Character '{c}' not found in CharsDictionary.");
                }
            }

            return stringBuilder.ToString();
        }

        private static Character GetCharacterFromChar(char c)
        {
            return c switch
            {
                '0' => Character.Zero,
                '1' => Character.One,
                '2' => Character.Two,
                '3' => Character.Three,
                '4' => Character.Four,
                '5' => Character.Five,
                '6' => Character.Six,
                '7' => Character.Seven,
                '8' => Character.Eight,
                '9' => Character.Nine,
                '+' => Character.Plus,
                '-' => Character.Minus,
                '.' => Character.Point,
                ',' => Character.Comma,
                'E' => Character.Exponent,
                '∞' => Character.PositiveInfinity,
                _ => throw new ArgumentException($"Invalid character '{c}'"),
            };
        }
    }
}
