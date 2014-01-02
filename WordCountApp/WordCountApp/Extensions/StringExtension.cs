using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
 
namespace WordCountApp.Extensions
{
    //Implemented as an extesion method to allow for usage across strings
    public static class StringExtension
    {
        //local variable to hold the valid characters regular expression
        private static readonly string ValidCharactersRegEx;

        /// <summary>
        /// Initializes the <see cref="StringExtension"/> class.
        /// </summary>
        static StringExtension()
        {
            //Get the valid character regular expression from config to allow for amendments without a recompile.
            ValidCharactersRegEx = ConfigurationManager.AppSettings["RegExValidChars"];
        }
 
        /// <summary>
        /// Strips the non alpha numeric characters.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string StripCharacters(this string value)
        {
            //Remove any characters that do not match the supplied regular expression
            //If the ValidCharactersRegEx is null, use an Empty String
            return new Regex(ValidCharactersRegEx ?? String.Empty).Replace(value, String.Empty);
        }
 
        /// <summary>
        /// Gets the word count.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetWordCount(this string value)
        {
            var result = new StringBuilder();

            //Get a valid words
            var words = StripCharacters(value);

            //only process if we have valid words
            if (!(String.IsNullOrWhiteSpace(words)))
            {
                //group the words by their lower case values and get their number of occurences
                var results = words.Split(' ')
                                   .GroupBy(x => x.ToLowerInvariant())
                                   .OrderByDescending(x => x.Count());

                //get the results containing words and their number of usages
                foreach (var item in results)
                {
                    result.AppendLine(string.Format("{0} - {1}", item.Key, item.Count()));
                }
            }
            else
            {
                result.AppendLine("No valid words supplied.");
            }

            return result.ToString();
        }  
    }
}
