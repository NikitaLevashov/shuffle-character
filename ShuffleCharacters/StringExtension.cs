using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShuffleCharacters
{
    public static class StringExtension
    {
        /// <summary>
        /// Shuffles characters in source string according some rule.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="count">The count of iterations.</param>
        /// <returns>Result string.</returns>
        /// <exception cref="ArgumentException">Source string is null or empty or white spaces.</exception>
        /// <exception cref="ArgumentException">Count of iterations less than 0.</exception>
        public static string ShuffleChars(string source, int count)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException(nameof(source));
            }

            if (count < 0)
            {
                throw new ArgumentException(nameof(source));
            }

            StringBuilder sourceCopy = new StringBuilder(source);
            StringBuilder sbOdd = new StringBuilder();
            StringBuilder sbEven = new StringBuilder();

            int resultCount = 0;

            for (int i = count; i > 0; i--)
            {
                int k = 0;

                sbEven.Clear();
                sbOdd.Clear();

                foreach (var s in sourceCopy.ToString())
                {
                    k++;

                    if (k % 2 == 0)
                    {
                        sbEven.Append(s);
                    }
                    else
                    {
                        sbOdd.Append(s);
                    }
                }

                sourceCopy.Clear();

                sourceCopy.Append(sbOdd.ToString() + sbEven.ToString());

                resultCount++;

                if (sourceCopy.ToString() == source)
                {
                    i = count % resultCount;
                    i++;
                }
            }

            return sourceCopy.ToString();
        }
    }
}
