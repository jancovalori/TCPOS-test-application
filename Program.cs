using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
  class Program
  {
        private static readonly string[] operations = { "+", "-", "*", "/" };
        static void Main(string[] args)
        {
            try
            {

            
            
              if ((args.Length == 0) || (args[0] == "interactive"))
                {
                
                    //----------OLD CODE---------------------
                    //Console.WriteLine("First argument: ");
                    //var readLine = Console.ReadLine();
                    //----------END OLD CODE---------------------

                    double firstArgument = GetNumberFromConsole("First Argument : ");


                    //----------OLD CODE---------------------
                    //Console.WriteLine("Second Argument: ");
                    //var secondArgument = Console.ReadLine();
                    //----------END OLD CODE---------------------

                    double secondArgument = GetNumberFromConsole("Second Argument: ");

                    //Ask operation to use

                    string Operation = GetOperationFromConsole("Enter the operation + (addition), - (subtraction), * (multiplication), / (division)");

                    writeResultToConsole(firstArgument, secondArgument, Operation);


                    //----------OLD CODE---------------------
                    //Console.WriteLine("Result: " + (firstArgument + secondArgument));
                    //----------END OLD CODE---------------------
                }
                else
                {
                    var readAllText = System.IO.File.ReadAllText(args[0]);
                    var strings = readAllText.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    var firstArgument = strings[0].Trim();

                    var secondArgument = strings[1].Trim();

                    //Get operation to use

                    var Operation = strings[2];


                    writeResultToConsole(double.Parse(firstArgument), double.Parse(secondArgument), Operation);

                    //----------OLD CODE---------------------
                    //Console.WriteLine("Result: " + (double.Parse(firstArgument) + double.Parse(secondArgument)));
                    //----------END OLD CODE---------------------

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore nell'applicazione: " + ex.Message.ToString());
            }
        }
        private static void writeResultToConsole(double firstArgument, double secondArgument, string Operation)
        {
            double result = 0;

            switch (Operation)
            {
                case "+":
                case "addition":
                    result = firstArgument + secondArgument;
                    break;
                case "-":
                case "subtraction":
                    result = firstArgument - secondArgument;
                    break;
                case "*":
                case "multiplication":
                    result = firstArgument * secondArgument;
                    break;
                case "/":
                case "division":
                    result = firstArgument / secondArgument;
                    break;

            }
            Console.WriteLine("Result of {0} {1} {2} = {3}", firstArgument, Operation, secondArgument, result);
            Console.ReadKey();
        }
        private static double GetNumberFromConsole(string outputText)
        {
            double parseInput;
            Console.Write(outputText);
            string consoleInput = Console.ReadLine();
            while (!double.TryParse(consoleInput, out parseInput))
            {
                Console.WriteLine("The input argument isn't valid, Try again inserting a number !");
                Console.Write(outputText);
                    consoleInput = Console.ReadLine();
            }
            return double.Parse(consoleInput);
        }
   
        private static string GetOperationFromConsole(string outputText)
        {
            Console.Write(outputText);
            string consoleInput = Console.ReadLine();
            while (!validateOperation(consoleInput))
            {
                Console.WriteLine("The input operation isn't valid !");
                Console.Write(outputText);
                consoleInput = Console.ReadLine();
            }
            return consoleInput;
        }
        private static bool validateOperation(string consoleInput)
        {
            return operations.Contains(consoleInput);
        }

    }
}

