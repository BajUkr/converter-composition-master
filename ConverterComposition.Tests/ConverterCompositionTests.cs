using System;
using Moq;
using NUnit.Framework;

namespace ConverterComposition.Tests
{
    [TestFixture]
    public class ConverterCompositionTests
    {
        [TestCase(123.78, "ru-ru")]
        [TestCase(-0.78, "de-de")]
        [TestCase(double.NaN, "en-us")]
        [TestCase(double.MaxValue, "en-us")]
        public void Transform_CreateDictionaryMethodCallOnceTimeWithAnyLanguage(double number, string cultureName)
        {
            var mock = new Mock<ICharsDictionaryFactory>();
            mock
                .Setup(factory => factory.CreateDictionary())
                .Returns(() => new ResourceCharsDictionaryFactory(cultureName).CreateDictionary());

            ICharsDictionaryFactory charsDictionaryFactory = mock.Object;

            var transformer = new Converter(charsDictionaryFactory);

            transformer.Convert(number);

            mock.Verify(provider => provider.CreateDictionary(), Times.Once);
        }

        [TestCase(123.78, "en-us", ExpectedResult = "one two three point seven eight")]
        [TestCase(-12.78, "en-us", ExpectedResult = "minus one two point seven eight")]
        [TestCase(-0.78, "en-us", ExpectedResult = "minus zero point seven eight")]
        [TestCase(123.78, "ru-ru", ExpectedResult = "один два три запятая семь восемь")]
        [TestCase(-12.78, "ru-ru", ExpectedResult = "минус один два запятая семь восемь")]
        [TestCase(-0.78, "ru-ru", ExpectedResult = "минус ноль запятая семь восемь")]
        [TestCase(123.78, "de-de", ExpectedResult = "eins zwei drei komma sieben acht")]
        [TestCase(-12.78, "de-de", ExpectedResult = "minus eins zwei komma sieben acht")]
        [TestCase(-0.78, "de-de", ExpectedResult = "minus null komma sieben acht")]
        [TestCase(double.PositiveInfinity, "en-us", ExpectedResult = "positive infinity")]
        [TestCase(double.PositiveInfinity, "ru-ru", ExpectedResult = "положительная бесконечность")]
        [TestCase(double.PositiveInfinity, "de-de", ExpectedResult = "positive unendlichkeit")]
        [TestCase(double.NegativeInfinity, "en-us", ExpectedResult = "negative infinity")]
        [TestCase(double.NegativeInfinity, "ru-ru", ExpectedResult = "отрицательная бесконечность")]
        [TestCase(double.NegativeInfinity, "de-de", ExpectedResult = "negative unendlichkeit")]
        [TestCase(double.NaN, "en-us", ExpectedResult = "not a number")]
        [TestCase(double.NaN, "ru-ru", ExpectedResult = "не число")]
        [TestCase(double.NaN, "de-de", ExpectedResult = "keine zahl")]
        [TestCase(double.Epsilon, "en-us", ExpectedResult = "epsilon")]
        [TestCase(double.Epsilon, "ru-ru", ExpectedResult = "эпсилон")]
        [TestCase(double.Epsilon, "de-de", ExpectedResult = "epsilon")]
        [TestCase(double.MinValue, "en-us", ExpectedResult = "minus one point seven nine seven six nine three one three four eight six two three one five seven exponent plus three zero eight")]
        [TestCase(double.MaxValue, "en-us", ExpectedResult = "one point seven nine seven six nine three one three four eight six two three one five seven exponent plus three zero eight")]
        [TestCase(6.67300E-11, "en-us", ExpectedResult = "six point six seven three exponent minus one one")]
        [TestCase(3.302e+23, "en-us", ExpectedResult = "three point three zero two exponent plus two three")]
        [TestCase(1234567890, "en-us", ExpectedResult = "one two three four five six seven eight nine zero")]
        [TestCase(double.MinValue, "ru-ru", ExpectedResult = "минус один запятая семь девять семь шесть девять три один три четыре восемь шесть два три один пять семь экспонента плюс три ноль восемь")]
        [TestCase(double.MaxValue, "ru-ru", ExpectedResult = "один запятая семь девять семь шесть девять три один три четыре восемь шесть два три один пять семь экспонента плюс три ноль восемь")]
        [TestCase(6.67300E-11, "ru-ru", ExpectedResult = "шесть запятая шесть семь три экспонента минус один один")]
        [TestCase(3.302e+23, "ru-ru", ExpectedResult = "три запятая три ноль два экспонента плюс два три")]
        [TestCase(1234567890, "ru-ru", ExpectedResult = "один два три четыре пять шесть семь восемь девять ноль")]
        [TestCase(double.MinValue, "de-de", ExpectedResult = "minus eins komma sieben neun sieben sechs neun drei eins drei vier acht sechs zwei drei eins fünf sieben exponent plus drei null acht")]
        [TestCase(double.MaxValue, "de-de", ExpectedResult = "eins komma sieben neun sieben sechs neun drei eins drei vier acht sechs zwei drei eins fünf sieben exponent plus drei null acht")]
        [TestCase(6.67300E-11, "de-de", ExpectedResult = "sechs komma sechs sieben drei exponent minus eins eins")]
        [TestCase(3.302e+23, "de-de", ExpectedResult = "drei komma drei null zwei exponent plus zwei drei")]
        [TestCase(1234567890, "de-de", ExpectedResult = "eins zwei drei vier fünf sechs sieben acht neun null")]
        public string Transform_CallWithVariousLanguages(double number, string cultureName)
        {
            var mock = new Mock<ICharsDictionaryFactory>();
            mock
                .Setup(factory => factory.CreateDictionary())
                .Returns(() => new ResourceCharsDictionaryFactory(cultureName).CreateDictionary());

            ICharsDictionaryFactory charsDictionaryFactory = mock.Object;

            Converter converter = new (charsDictionaryFactory);

            return converter.Convert(number);
        }

        [Test]
        public void Transform_FactoryIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Converter(null), "Factory cannot be null.");
        }
    }
}
