using System;
using System.IO;

namespace PrimeFactorization.ConsoleApp.Input
{
    public class InputParametersParser
    {
        public static bool Parse(string[] args, out InputParameters parameters)
        {
            parameters = new InputParameters();
            
            if (args == null || args.Length < 1)
            {
                Console.WriteLine("Missing input file path!");
                return false;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"File '{args[0]}' does not exist!");
                return false;
            }

            parameters.InputFilePath = args[0];

            if (args.Length > 1)
            {
                if (!Directory.Exists(args[1]))
                {
                    Console.WriteLine($"Directory '{args[1]}' does not exist!");
                    return false;
                }

                parameters.OutputDirectory = args[1];
            }
            else
            {
                parameters.OutputDirectory = Directory.GetCurrentDirectory();
            }

            return true;
        }
    }
}
