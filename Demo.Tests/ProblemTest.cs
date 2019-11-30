using Demo.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Demo.Tests
{
    /*
Write an algorithm which reverses the letters in words, like: 
Input: I love Taxify 
Output:I evol yfixaT
Input is character array (not string) and output should also be character array. Function needs to work in-place, modify the input array itself. Don't use any extra arrays, string objects or language provider libraries. Use of temporary variables is allowed.
Example in Java:
Input: char[] input = ['I', ' ', 'l','o','v','e',' ','T','a','x','i','f','y'];
public static char[] reverseWords(char [] input) {
	// write your code here
	return input;
}
Output: ['I', ' ', 'e','v','o','l',' ','y','f','i','x','a','T'];

Example is in Java, but choice of programming language is free.Please write the code in the web browser, don't test or run it in your IDE.
Extra: you will earn extra points if you write unit tests for this function.

Live coding result: https://www.interviewzen.com/interview/4FPFdr3
     */
    [TestClass]
    public class ProblemTest
    {
        // tests
        [TestMethod]
        public void testReverseWords()
        {
            var testSamples = new Dictionary<char[], char[]>()
            {
                {new char[] {}, new char[] {}}, // empty array
                {new char[] {' '}, new char[] {' '}}, // no words
                {new char[] {'i'}, new char[] {'i'}}, // odd length word
                {new char[] {'i', '1'}, new char[] {'1', 'i'}}, // even length word
                {new char[] {' ', 'i', '1', ' '}, new char[] {' ', '1', 'i', ' '}}, // leading and trailing spaces
                {new char[] {'I', ' ', 'l','o','v','e',' ','T','a','x','i','f','y'}, new char[] {'I', ' ', 'e','v','o','l',' ','y','f','i','x','a','T'}}, // demo sample
            };

            foreach (var sample in testSamples)
            {
                runTestSample(sample.Key, sample.Value);
            }
        }

        public static void runTestSample(char[] test, char[] expected)
        {
            var result = Problem.reverseWords(test);
            Assert.IsTrue(areEqual(result, expected));
        }

        public static bool areEqual(char[] a1, char[] a2)
        {
            if (a1 == null || a2 == null || (a1.Length != a2.Length))
            {
                return false;
            }

            for (int i = 0; i < a1.Length; i += 1)
            {
                if (a1[i] != a2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
