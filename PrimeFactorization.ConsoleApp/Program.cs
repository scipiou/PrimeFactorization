using System.Threading.Tasks;
using PrimeFactorization.ConsoleApp.Input;
using PrimeFactorization.ConsoleApp.Output;
using PrimeFactorization.ConsoleApp.Output.Interfaces;
using PrimeFactorization.ConsoleApp.PrimeFactorizationFinders;

namespace PrimeFactorization.ConsoleApp
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var isInputValid = InputParametersParser.Parse(args, out var parameters);

            if (!isInputValid)
            {
                return;
            }

            var resultOnlyFormatter = new ResultOnlyBasicFormatter();
            var richFormatter = new RichBasicFormatter();
            var exporter = new BasicTextExporter(new IFileOutputLinesFormatter[] { resultOnlyFormatter, richFormatter });
            var factFinder = new BasicPrimeFactorizationFinder();
            var fileProcessor = new FileProcessor(exporter, factFinder);

            await fileProcessor.ProcessFileAsync(parameters);
        }
    }
}
