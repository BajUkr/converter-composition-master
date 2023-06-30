# Converter. Composition

Intermediate level task for practicing inheritance, interfaces, composition, aggregation, Factory Method design pattern, resources files, mock tests.

Estimated time to complete the task - 2h.

The task requires .NET 6 SDK installed.

## Task description

Solve the converting problem of the real number to its "in words" string representations in any given language. 

- Review the articles
    - [Difference between Composition and Aggregation](https://www.c-sharpcorner.com/article/difference-between-composition-and-aggregation/)
    - [Aggregation Vs Composition: A Simple Practical Approach](https://www.c-sharpcorner.com/UploadFile/97fc7a/aggregation-vs-composition-a-simple-practical-approach/)
    - [Factory Method](https://refactoring.guru/design-patterns/factory-method)
    - [Resources files](https://docs.microsoft.com/en-us/dotnet/core/extensions/work-with-resx-files-programmatically)

- Implement [Converter](ConverterComposition/Converter.cs) class whose `Convert` method converts real number to its "in words" string representation in any given language.     
        **Requirement**: The `Converter` class should be manage the lifetime of the `Charts Dictionary` class object, but do it with an additional abstraction, the factory class.     
        Use for the solution following type system:     
        - [Сharacter](ConverterComposition/Character.cs) enum consists of a set of words for all characters that a real number can contains.     
        - [CharsDictionary](ConverterComposition/CharsDictionary.cs) class presents the dictionary of correspondences of the number characters to their word analogs in given language.    
        - [ICharsDictionaryFactory](ConverterComposition/ICharsDictionaryFactory.cs) interface presents the factory of dictionary of the chars correspondences to their word analogs in given language.   
    
- Study [ResourceCharsDictionaryFactory](ConverterComposition.Tests/ResourceCharsDictionaryFactory.cs) class that presents the dictionary of chars correspondences of the number to their word analogs in several languages (english, german, russian).      
        - To support several languages are used [resources files](https://docs.microsoft.com/en-us/dotnet/core/extensions/work-with-resx-files-programmatically).     
        - Study generated code of the [Dictionary.Designer](ConverterComposition.Tests/Resources/Dictionary.Designer.cs) file.         

- Run [unit и mock tests](ConverterComposition.Tests/ConverterCompositionTests.cs)    

- Answer the following questions and discuss it with your trainer, if you work in a regular group.  
    - What is an interface?
    - Why use interfaces?
    - What is association?
    - What is composition? 
    - What is aggregation? Why we need aggregation?
    - How to keep control of the whole over the lifetime of the part while reducing their cohesion?
    - What is difference between composition and aggregation?
    - Factory Method Pattern. When and why to use?
    - Why resource files are used?
