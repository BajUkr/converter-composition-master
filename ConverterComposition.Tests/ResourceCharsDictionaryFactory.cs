using System;
using System.Collections.Generic;
using System.Globalization;
using ConverterComposition.Tests.Resources;

namespace ConverterComposition.Tests
{
    /// <summary>
    /// Presents the factory of the dictionary of the char correspondences of the number to their word analogs in given language.
    /// </summary>
    public class ResourceCharsDictionaryFactory : ICharsDictionaryFactory
    {
        private readonly string cultureName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceCharsDictionaryFactory"/> class.
        /// </summary>
        /// <param name="cultureName">Name of the culture.</param>
        /// <exception cref="System.ArgumentException">Thrown when cultureName is null or empty.</exception>
        public ResourceCharsDictionaryFactory(string? cultureName)
        {
            ResourceDictionary.Culture = cultureName is null
                ? throw new ArgumentException($"{nameof(cultureName)} cannot be null or empty.", nameof(cultureName))
                : new CultureInfo(cultureName);
            this.cultureName = cultureName;
        }

        /// <inheritdoc cref="ICharsDictionaryFactory.CreateDictionary"/>
        public CharsDictionary CreateDictionary()
        {
            return new CharsDictionary
            {
                Dictionary = new Dictionary<Character, string>
                {
                    [Character.Zero] = ResourceDictionary.Zero,
                    [Character.One] = ResourceDictionary.One,
                    [Character.Two] = ResourceDictionary.Two,
                    [Character.Three] = ResourceDictionary.Three,
                    [Character.Four] = ResourceDictionary.Four,
                    [Character.Five] = ResourceDictionary.Five,
                    [Character.Six] = ResourceDictionary.Six,
                    [Character.Seven] = ResourceDictionary.Seven,
                    [Character.Eight] = ResourceDictionary.Eight,
                    [Character.Nine] = ResourceDictionary.Nine,
                    [Character.Minus] = ResourceDictionary.Minus,
                    [Character.Plus] = ResourceDictionary.Plus,
                    [Character.Point] = ResourceDictionary.Point,
                    [Character.Comma] = ResourceDictionary.Comma,
                    [Character.Exponent] = ResourceDictionary.Exponent,
                    [Character.Epsilon] = ResourceDictionary.Epsilon,
                    [Character.NegativeInfinity] = ResourceDictionary.NegativeInfinity,
                    [Character.PositiveInfinity] = ResourceDictionary.PositiveInfinity,
                    [Character.NaN] = ResourceDictionary.NaN,
                },
                CultureName = this.cultureName,
            };
        }
    }
}
