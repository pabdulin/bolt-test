using System;

namespace Demo.Lib
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
    public class Problem
    {
        public static char[] reverseWords(char[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var wordStart = 0;
            while (true)
            {
                if (wordStart >= input.Length)
                {
                    // end of char array
                    break;
                }

                // skip to word start
                for (var i = wordStart; i < input.Length; i += 1)
                {
                    var testChar = input[i];
                    wordStart = i;
                    if (!isWhitespace(testChar))
                    {
                        break;
                    }
                }

                // char is not actually a symbol, it is at the end of the input then
                // == end of char array with whitespace
                if (isWhitespace(input[wordStart]))
                {
                    break;
                }

                // seek for wordEnd
                var wordEnd = wordStart;
                for (var i = wordEnd + 1; i < input.Length; i++)
                {
                    var testChar = input[i];
                    if (isWhitespace(testChar))
                    {
                        break;
                    }
                    wordEnd = i;
                }

                // indices found, now reverse
                reverseChars(wordStart, wordEnd, input);

                // advance to next possible word
                wordStart = wordEnd + 1;
            }

            return input;
        }

        public static bool isWhitespace(char symbol)
        {
            return symbol == ' ';
        }

        public static void reverseChars(int start, int end, char[] input)
        {
            while ((end - start) > 0)
            {
                var tempStart = input[start];
                input[start] = input[end];
                input[end] = tempStart;
                end -= 1;
                start += 1;
            }
        }

    }
}
