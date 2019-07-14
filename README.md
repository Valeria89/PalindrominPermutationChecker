# PalindrominPermutationChecker

This project contains a string analyser that can detect if a string contains a permutation of itself that is palindrom.

## Dependencies

- .NET Framework 4.7.1

## Description

The project includes a class called `StringAnalyzer` that is responsible for checking if a permutation of a given string is a palindrom.

### Assumptions

1 - The function accepts input as a String value;
2 - A sentence it's a string terminating with a `.` in the end;
3 - The input string can be manipulated in terms of char upper to lower case (every upper case char will be transformed into lower case)
4 - The input string is going to be trimmed so no spaces are going to be considered.

## Run the tests

The class can be tested using the test called `PalindromicPermutationsTest`. The class has as an input a "class of inputs" for testing the correctness of the algorithm (the inputs are devided as `input` and `expectedValue` in a csv file).

