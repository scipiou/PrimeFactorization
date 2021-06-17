using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using PrimeFactorization.ConsoleApp.Input;
using PrimeFactorization.ConsoleApp.Output.Interfaces;
using PrimeFactorization.ConsoleApp.PrimeFactorizationFinders.Interfaces;

namespace PrimeFactorization.ConsoleApp
{
    public class FileProcessor
    {
        private static bool _abortMainLoop;
        private const int BufferSize = 4096;
        private const int BatchWriteLinesCount = 1000;
        private const int BatchWriteProgressLinesCount = 100;
        private const string ResultFileSuffix = "_results";

        private readonly IFileExporter _exporter;
        private readonly IPrimeFactorizationFinder _factFinder;

        public FileProcessor(IFileExporter exporter, IPrimeFactorizationFinder factFinder)
        {
            _abortMainLoop = false;
            _exporter = exporter;
            _factFinder = factFinder;

            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                _abortMainLoop = true;
            };
        }

        public async Task ProcessFileAsync(InputParameters parameters)
        {
            int lineNr = 0;
            int lineCountWrite = 0;
            int lineCountProgress = 0;
            var linesToWrite = new List<FactorizationResult>();
            string fileName = Path.GetFileNameWithoutExtension(parameters.InputFilePath);
            string outputFileBaseName = $"{parameters.OutputDirectory}\\{fileName}{ResultFileSuffix}";

            using (var fileStream = File.OpenRead(parameters.InputFilePath))
            using (var streamReader = new StreamReader(fileStream, Encoding.ASCII, true, BufferSize))
            {
                string line;
                _exporter.InitFiles(outputFileBaseName);

                while (!_abortMainLoop && (line = await streamReader.ReadLineAsync()) != null)
                {
                    ++lineNr;
                    ++lineCountWrite;
                    ++lineCountProgress;

                    bool isParseSuccessful = ulong.TryParse(line, out var res);
                    if (isParseSuccessful && res < 2)
                    {
                        isParseSuccessful = false;
                    }

                    linesToWrite.Add(isParseSuccessful ? 
                        new FactorizationResult
                        {
                            Number = res,
                            PrimeFactors = _factFinder.FindPrimeFactorization(res)
                        } 
                        : new FactorizationResult { IsError = true });


                    if (lineCountWrite == BatchWriteLinesCount)
                    {
                        await _exporter.AppendLinesAsync(linesToWrite, outputFileBaseName);

                        linesToWrite.Clear();
                        lineCountWrite = 0;
                    }

                    if (lineCountProgress == BatchWriteProgressLinesCount)
                    {
                        Console.Write($"\r {lineNr} lines processed");
                        lineCountProgress = 0;
                    }
                }
            }

            if (_abortMainLoop)
            {
                _exporter.CleanupAbort(outputFileBaseName);
                Console.Write("\n Processing file aborted");
            }
            else
            {
                await _exporter.AppendLinesAsync(linesToWrite, outputFileBaseName);

                Console.Write($"\r {lineNr} lines processed");
                Console.WriteLine("\n Processing file finished. Results saved.");
            }
        }
    }
}
