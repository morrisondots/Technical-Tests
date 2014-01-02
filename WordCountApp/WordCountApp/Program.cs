using System;

using WordCountApp.Extensions;

namespace WordCountApp
{
    class Program
    {
        //Default sentence value supplied in requirements spec
        private const string DefaultValue = "This is a statement, and so is this.";

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            string sentence;
            
            //If not argument supplied then use the default sentence value
            if (args.Length == 0)
            {
                sentence = DefaultValue;
            }
            else if(!(String.IsNullOrWhiteSpace((args[0]))))
            {
                //use another sentence if supplied as an argument
                sentence = args[0];
            }
            else
            {
                //Output a message to the user informing them that they have supplied an incorrect argument 
                Console.WriteLine("Please supply only one quoted parameter value to use as a custom sentence value.");

                //Wait for user feedback
                Console.WriteLine("Press enter key to continue...");
                Console.ReadLine();
                return;
            }

            var result = sentence.GetWordCount();
            //Show supplied input value
            Console.WriteLine(String.Format("Input: \"{0}\"", sentence));
            
            //Show ouput value
            Console.WriteLine(String.Format("Output:"));
            Console.WriteLine(result);

            //Wait for user feedback
            Console.WriteLine("Press enter key to continue...");
            Console.ReadLine();
        }
    }
}
