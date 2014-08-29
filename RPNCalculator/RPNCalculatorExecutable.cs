using System;

/**
 * RPN Calculator - Basic implementation of a reverse polish notation calculator
 * 
 * Executable entry point for the console program
 * 
 * @author      Ofer Tal
 * @see         https://gist.github.com/nilbus/7029600f8e6446c538f5
 */
namespace org.shmoop.RPNCalculator
{
    class RPNCalculatorExecutable
    {
        /**
         * PROMPT is the string "shell prompt" we present to the user to indicate we are ready for input
         */
        private const string PROMPT = "> ";

        /**
         * Main is the application entry point
         * 
         * functionality: 
         * - creates an instance of the calculator object
         * - enters an endless input to receive and process user input
         *    - present prompt and accept user input
         *    - clean/normalize user input
         *    - check for "environment commands" (q = quit) and process them
         *    - Hand over calculation to the calculator object
         *    - present output from calculator or error message if an exception is caught.
         * 
         * @param args      command line params, ignored by this application
         */
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            
            Console.Write(PROMPT); // first prompt displayed prior to input loop
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                // remove any whitespace around the input, normalize to lowercase in case future oprtators use
                // english language command triggers (e.g. "sqrt")
                string cleanInput = input.Trim().ToLower();

                // process non-calculator commands directly in main control loop
                if (cleanInput == "q")
                {
                    Environment.Exit(0);
                }
                else
                {
                    // input is expected to be valid calculator input.
                    // hand it over to the calculator instance and display results
                    try
                    {
                        string calculatorOutput = calculator.ProcessUserInput(cleanInput);
                        Console.WriteLine(calculatorOutput);
                    }
                    catch (Exception e)
                    {
                        // calculator throws an exception if it wasn't able to process the
                        // input correctly. display it to the user
                        Console.WriteLine("ERROR: " + e.Message);
                    }
                }
                // don't forget to show the prompt again before requesting next input!
                Console.Write(PROMPT);
            }
        }
    }
}
